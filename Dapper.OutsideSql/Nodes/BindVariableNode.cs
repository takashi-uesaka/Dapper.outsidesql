#region copyright

// /*
//  * Copyright 2018-2018 Hiroaki Fujii  All rights reserved. 
//  *
//  * Licensed under the Apache License, Version 2.0 (the "License");
//  * you may not use this file except in compliance with the License.
//  * You may obtain a copy of the License at
//  *
//  *     http://www.apache.org/licenses/LICENSE-2.0
//  *
//  * Unless required by applicable law or agreed to in writing, software
//  * distributed under the License is distributed on an "AS IS" BASIS,
//  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//  * either express or implied. See the License for the specific language
//  * governing permissions and limitations under the License.
//  */

#endregion

#region using

using System;

#endregion

namespace Jiifureit.Dapper.OutsideSql.Nodes
{
    public class BindVariableNode : AbstractNode
    {
        public BindVariableNode(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; }

        public override void Accept(ICommandContext ctx)
        {
            var value = ctx.GetArg(Expression);
            Type type = null;
            if (value != null)
                type = value.GetType();

            ctx.AddSql(value, type, Expression.Replace('.', '_'));
        }
    }
}