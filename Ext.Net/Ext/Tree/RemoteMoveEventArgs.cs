/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0 - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-24
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class RemoteMoveEventArgs : RemoteActionEventArgs
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RemoteMoveEventArgs(string serviceParams, ParameterCollection extraParams) : base(serviceParams, extraParams) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DropPoint Point
        {
            get
            {
                string point = this.GetValue<string>("point");
                return (DropPoint)Enum.Parse(typeof(DropPoint), point, true);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string TargetNodeID
        {
            get
            {
                return this.GetValue<string>("targetId");
            }
        }

        public List<string> Nodes
        {
            get
            {
                if (this.ServiceParams == null)
                {
                    return new List<string>(0);
                }

                JProperty p = this.ServiceParams.Property("ids");

                if (p == null || p.Value == null)
                {
                    return new List<string>(0);
                }

                var nodes = (JArray)p.Value;
                var list = new List<string>(nodes.Count);
                for (int i = 0; i < nodes.Count; i++)
			    {
                    list.Add(nodes[i].Value<string>());
			    }

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string NodeID
        {
            get
            {
                return this.GetValue<string>("id");
            }
        }
    }
}