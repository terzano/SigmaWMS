#region License
//-----------------------------------------------------------------------
// <copyright file="PageBase.cs" company="Pi2 LLC">
//     Copyright (c) Pi2 LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#endregion

#region Using Directives
using System.Web.UI;
using Funq;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
#endregion

namespace Sigma.Api.App_Start
{
	//A customizeable typed UserSession that can be extended with your own properties
	public class CustomUserSession : AuthUserSession
	{
		public string CustomProperty { get; set; }
	}

	public class PageBase : Page
	{
		private Container container;
		public Container Container
		{
			get { return container ?? (container = AppHostBase.Instance.Container); }
		}

		protected string SessionKey
		{
			get
			{
				var sessionId = SessionFeature.GetSessionId();
				return sessionId == null ? null : SessionFeature.GetSessionKey(sessionId);
			}
		}

		private CustomUserSession userSession;
		protected CustomUserSession UserSession
		{
			get
			{
				if (userSession != null) return userSession;
				if (SessionKey != null)
					userSession = this.Cache.Get<CustomUserSession>(SessionKey);
				else
					SessionFeature.CreateSessionIds();

				var unAuthorizedSession = new CustomUserSession();
				return userSession ?? (userSession = unAuthorizedSession);
			}
		}

		public void ClearSession()
		{
			userSession = null;
			this.Cache.Remove(SessionKey);
		}

		public new ICacheClient Cache
		{
			get { return Container.Resolve<ICacheClient>(); }
		}

		public ISessionFactory SessionFactory
		{
			get { return Container.Resolve<ISessionFactory>(); }
		}

		private ISession session;
		public new ISession Session
		{
			get
			{
				return session ?? (session = SessionFactory.GetOrCreateSession());
			}
		}
	}
}