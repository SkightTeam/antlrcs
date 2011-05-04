﻿/*
 * [The "BSD licence"]
 * Copyright (c) 2005-2008 Terence Parr
 * All rights reserved.
 *
 * Conversion to C#:
 * Copyright (c) 2008 Sam Harwell, Pixel Mine, Inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. The name of the author may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

namespace Antlr3.Analysis
{
    using Rule = Antlr3.Tool.Rule;

    /** A transition used to reference another rule.  It tracks two targets
     *  really: the actual transition target and the state following the
     *  state that refers to the other rule.  Conversion of an NFA that
     *  falls off the end of a rule will be able to figure out who invoked
     *  that rule because of these special transitions.
     */
    public class RuleClosureTransition : Transition
    {
        /** Ptr to the rule definition object for this rule ref */
        private readonly Rule _rule;

        /** What node to begin computations following ref to rule */
        private readonly NFAState _followState;

        public RuleClosureTransition( Rule rule,
                                     NFAState ruleStart,
                                     NFAState followState )
            : base( Label.EPSILON, ruleStart )
        {
            this._rule = rule;
            this._followState = followState;
        }

        public Rule Rule
        {
            get
            {
                return _rule;
            }
        }

        public NFAState FollowState
        {
            get
            {
                return _followState;
            }
        }
    }
}
