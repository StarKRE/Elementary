using System;
using System.Collections.Generic;
using System.Linq;

namespace Elementary
{
    /// <summary>
    ///     <para>Throws when implementation element is absent in the inheritance table.</para>
    /// </summary>
    internal sealed class NoImplementationException : Exception
    {
        private readonly Type targetType;

        public NoImplementationException(Type targetType)
        {
            this.targetType = targetType;
        }

        public override string Message
        {
            get
            {
                const string messageFormat =
                    "{0} hasn't implementation! Didn't you forget to" +
                    " add attribute [Using] over implementation class?";
                var message = string.Format(messageFormat, this.targetType.Name);
                return message;
            }
        }
    }

    
    /// <summary>
    ///     <para>Throws when several implementation elements may be used as instance under abstract contructor.</para>
    /// </summary>
    internal sealed class SeveralImplementationsException : Exception
    {
        private readonly Type targetType;

        private readonly IEnumerable<Type> derivedTypes;

        public SeveralImplementationsException(Type targetType, IEnumerable<Type> derivedTypes)
        {
            this.targetType = targetType;
            this.derivedTypes = derivedTypes;
        }

        public override string Message
        {
            get
            {
                const string messageFormat =
                    "{0} has several implementations: {1}\n" +
                    "Please, choose one implementation from these!";
                var derivedTypeNames = string.Join(", ", this.derivedTypes.Select(it => it.Name));
                var message = string.Format(messageFormat, this.targetType.Name, derivedTypeNames);
                return message;
            }
        }
    }
}
