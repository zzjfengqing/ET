﻿
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ET
{
	[MessageHandler]
	public class M2C_CreateUnitsHandler : AMHandler<M2C_CreateUnits>
	{
		protected override async ETVoid Run(Session session, M2C_CreateUnits message)
		{	
			Log.Debug("我收到了 创建Unit的服务器消息");

            UnitComponent unitComponent = session.Domain.GetComponent<UnitComponent>();

            foreach (UnitInfo unitInfo in message.Units)
            {
                if (unitComponent.Get(unitInfo.UnitId) != null)
                {
                    continue;
                }
                Unit unit = UnitFactory.Create(session.Domain, unitInfo);
            }

            await ETTask.CompletedTask;
		}
	}
}
