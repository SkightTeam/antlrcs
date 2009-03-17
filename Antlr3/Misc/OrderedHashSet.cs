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

namespace Antlr3.Misc
{
    using System.Collections.Generic;

    using NotSupportedException = System.NotSupportedException;

    /** A HashMap that remembers the order that the elements were added.
     *  You can alter the ith element with set(i,value) too :)  Unique list.
     *  I need the replace/set-element-i functionality so I'm subclassing
     *  OrderedHashSet.
     */
    public class OrderedHashSet<T> : ICollection<T>
    {
        /** Track the elements as they are added to the set */
        protected IList<T> _elements = new List<T>();

        protected HashSet<T> _elementSet = new HashSet<T>();

        public T get( int i )
        {
            return _elements[i];
        }

        /** Replace an existing value with a new value; updates the element
         *  list and the hash table, but not the key as that has not changed.
         */
        public T set( int i, T value )
        {
            T oldElement = _elements[i];
            _elements[i] = value; // update list

            _elementSet.Remove( oldElement );
            _elementSet.Add( value );

            //throw new NotImplementedException();
            //base.Remove( oldElement ); // now update the set: remove/add
            //base.Add( value );
            return oldElement;
        }

        /** Add a value to list; keep in hashtable for consistency also;
         *  Key is object itself.  Good for say asking if a certain string is in
         *  a list of strings.
         */
        public bool add( T value )
        {
            if ( _elementSet.Add( value ) )
            {
                _elements.Add( value );
                return true;
            }

            return false;
            //throw new NotImplementedException();
            //boolean result = base.add( value );
            //if ( result )
            //{  // only track if new element not in set
            //    elements.add( (T)value );
            //}
            //return result;
        }

        public bool remove( T o )
        {
            throw new NotSupportedException();
            /*
            elements.remove(o);
            return super.remove(o);
            */
        }

        public void clear()
        {
            _elements.Clear();
            _elementSet.Clear();
        }

        /** Return the List holding list of table elements.  Note that you are
         *  NOT getting a copy so don't write to the list.
         */
        public IList<T> getElements()
        {
            return _elements;
        }

        public int size()
        {
            /*
            if ( elements.size()!=super.size() ) {
                ErrorManager.internalError("OrderedHashSet: elements and set size differs; "+
                                           elements.size()+"!="+super.size());
            }
            */
            return _elements.Count;
        }

        public override string ToString()
        {
            return _elements.ToString();
        }

        #region ICollection<T> Members

        public void Add( T item )
        {
            this.add( item );
        }

        public void Clear()
        {
            this.clear();
        }

        public bool Contains( T item )
        {
            return _elementSet.Contains( item );
        }

        public void CopyTo( T[] array, int arrayIndex )
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get
            {
                return _elements.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public bool Remove( T item )
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}