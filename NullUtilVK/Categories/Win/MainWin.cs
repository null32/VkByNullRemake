using NullUtilVK.Enums.SafetyEnums;
using NullUtilVK.Model;
using NullUtilVK.Model.EventArg.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Categories.Win
{
    public class MainWin : IDisposable
    {
        #region Sub categories
        public AudioWin AudioWin
        {
            get
            {
                if (_AudioWin == null)
                    _AudioWin = new AudioWin(MainApi);
                return _AudioWin;
            }
        }
        private AudioWin _AudioWin;
        #endregion

        NullUtilVk MainApi;
        List<AuthInstance> Instances;

        bool _isAuthorizerWorking = false;

        string build = "20";

        internal MainWin(NullUtilVk Api)
        {
            MainApi = Api;
        }

        public Task InstAdd(AuthInstance Inst)
        {
            return Task.Run(() =>
                {
                    MainApi.Config.AddAuthInst(Inst);
                    LoadAuthInstances();
                });
        }
        public Task InstUpd(AuthInstance Inst)
        {
            return Task.Run(() =>
                {
                    MainApi.Config.UpdateAuthInst(Inst);
                    LoadAuthInstances();
                });
        }
        public Task InstDel(AuthInstance Inst)
        {
            return Task.Run(() =>
                {
                    MainApi.Config.DeleteAuthInst(Inst);
                    LoadAuthInstances();
                });
        }

        public Task Login(AuthInstance Inst)
        {
            MainApi.ClientLog("Started authorization");
            if (UpdateOnLogin != null)
                UpdateOnLogin(this, new UpdateOnLoginEventArgs(false, Enums.Win.WorkerState.Working, "Authorization: Working"));
            return Task.Run(() =>
            {
                _isAuthorizerWorking = true;
                bool success = false;
                if (Inst.IsNormal)
                    success = MainApi.Authorize(Inst.EmailOrAccKey, Inst.PassOrId);
                else
                {
                    long userId = 0;
                    try
                    {
                        userId = Convert.ToInt64(Inst.PassOrId);
                    }
                    catch (Exception)
                    {
                        if (ShowMBox != null)
                            ShowMBox(this, new ShowMBoxEventArgs(LogStrings.Error.Auth.InvalidAccKey, "Error", System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxButtons.OK));
                        _isAuthorizerWorking = false;
                        CheckAuthorization();
                        return;
                    }
                    success = MainApi.Authorize(Inst.EmailOrAccKey, userId);
                }
                if (!success)
                {
                    if (ShowMBox != null)
                        ShowMBox(this, new ShowMBoxEventArgs("Failed to authorize you at vk.com.\nThis may happen because of:\n\t1.Invalid email or password.\n\t2.You have no internet connection.\n\t3.Vk servers are down.", "Authorization error", System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxButtons.OK));
                }
                _isAuthorizerWorking = false;
                CheckAuthorization();
            });
        }
        public Task Logout()
        {
            return Task.Run(() =>
                {
                    MainApi.LogOut();
                    CheckAuthorization();
                });
        }
        public Task LoadAuthInstances()
        {
            return Task.Run(() =>
                {
                    Instances = MainApi.Config.GetAuthInsts();
                    if (UpdateInstanceList != null)
                    {
                        UpdateInstanceList(this, new UpdateInstancesEventArgs(Instances, 0));
                    }
                });
        }
        public Task SelectAuthInstance(int index)
        {
            return Task.Run(() =>
                {
                    if (UpdateTextboxex != null)
                        UpdateTextboxex(this, new UpdateTextboxexEventArgs(Instances[index], index));
                });
        }
        public Task CheckAuthorization()
        {
            return Task.Run(()=>
                {
                    if (UpdateOnLogin != null)
                        if (_isAuthorizerWorking)
                            UpdateOnLogin(this, new UpdateOnLoginEventArgs(MainApi.IsAuthorize, Enums.Win.WorkerState.Working, "Authorizer: Working"));
                        else
                            if (MainApi.IsAuthorize)
                            {
                                var user = MainApi.User.Get();
                                string authStatus = "Authorized as {0} {1} id:{2}";
                                UpdateOnLogin(this, new UpdateOnLoginEventArgs(true, Enums.Win.WorkerState.Done, string.Format(authStatus, user.FirstName, user.LastName, user.Id)));
                            }
                            else
                                UpdateOnLogin(this, new UpdateOnLoginEventArgs(false, Enums.Win.WorkerState.None, "Authorization: None"));
                });
        }

        public event EventHandler<UpdateInstancesEventArgs> UpdateInstanceList;
        public event EventHandler<UpdateTextboxexEventArgs> UpdateTextboxex;
        public event EventHandler<UpdateOnLoginEventArgs> UpdateOnLogin;
        public event EventHandler<ShowMBoxEventArgs> ShowMBox;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_AudioWin != null)
                    _AudioWin.Dispose();
            }
        }
    }
}
