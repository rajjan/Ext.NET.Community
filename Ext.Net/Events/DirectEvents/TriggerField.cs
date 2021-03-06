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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TriggerFieldDirectEvents : TextFieldDirectEvents
    {
        public TriggerFieldDirectEvents() { }

        public TriggerFieldDirectEvents(Observable parent) { this.Parent = parent; }

        private ComponentDirectEvent triggerClick;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "item", typeof(Field), "This trigger field")]
        [ListenerArgument(1, "trigger", typeof(object), "trigger")]
        [ListenerArgument(2, "index", typeof(int), "trigger index")]
        [ListenerArgument(3, "tag", typeof(string), "trigger tag")]
        [ListenerArgument(4, "e", typeof(int), "click event")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("triggerclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent TriggerClick
        {
            get
            {
                if (this.triggerClick == null)
                {
                    this.triggerClick = new ComponentDirectEvent(this);
                }

                return this.triggerClick;
            }
        }
    }
}