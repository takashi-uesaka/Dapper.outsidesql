#region Copyright

/*
 * Copyright 2005-2015 the Seasar Foundation and the Others.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */

#endregion

#region using

using System;
using System.Collections;
using Jiifureit.Dapper.OutsideSql.Utility;

#endregion

namespace Jiifureit.Dapper.OutsideSql.Nodes
{
    public abstract class AbstractNode : INode
    {
        private readonly IList _children = new ArrayList();

        protected object InvokeExpression(string expression, ICommandContext ctx)
        {
            var ht = new Hashtable
            {
                ["self"] = ctx,
                ["out"] = Console.Out,
                ["err"] = Console.Error
            };
            return ScriptEvaluateUtil.Evaluate(expression, ht, null);
        }

        #region INode �����o

        public int ChildSize => _children.Count;

        public INode GetChild(int index)
        {
            return (INode) _children[index];
        }

        public void AddChild(INode node)
        {
            _children.Add(node);
        }

        public bool ContainsChild(Type childType)
        {
            foreach (INode child in _children)
                if (child.GetType() == childType)
                    return true;
            return false;
        }

        public abstract void Accept(ICommandContext ctx);

        #endregion
    }
}