using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using LCore.Extensions;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LCore.Numbers
    {
    /// <summary>
    /// Base class to extend for native (and potentially non-native) number types
    /// </summary>
    /// <typeparam name="T">The Type of the number object</typeparam>
    /// <typeparam name="U"></typeparam>

    public abstract class Number<T, U> : Number<T>
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        where U : Number<T, U>, new()
        {
        /// <summary>
        /// Implicitally convert a UShortNumber to a ushort
        /// </summary>
        /// <param name="i">The UShortNumber to convert</param>
        public static implicit operator T(Number<T, U> i)
            {
            return i.Value;
            }
/*
        /// <summary>
        /// Performs the division operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator /(Number<T, U> Number1, U Number2)
            {
            return Number1.Divide(Number2);
            }
        /// <summary>
        /// Performs the multiplication operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator *(Number<T, U> Number1, U Number2)
            {
            return Number1.Multiply(Number2);
            }
        /// <summary>
        /// Performs the subtraction operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator -(Number<T, U> Number1, U Number2)
            {
            return Number1.Subtract(Number2);
            }
        /// <summary>
        /// Performs the addition operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator +(Number<T, U> Number1, U Number2)
            {
            return Number1.Add(Number2);
            }*/

        /// <summary>
        /// Create a new Number wrapper for a native number type
        /// </summary>
        protected Number()
            {
            }

        /// <summary>
        /// Create a new Number wrapper for a native number type
        /// </summary>
        /// <param name="Value">The number value</param>
        protected Number(T Value) : base(Value)
            {
            }

        }
    /// <summary>
    /// Base class to extend for native (and potentially non-native) number types
    /// </summary>
    /// <typeparam name="T">The Type of the number object</typeparam>
    public abstract class Number<T> : Number, INumber<T>
        where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {
        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <returns>A Number result</returns>
        public static Number operator /(Number<T> Number1, T Number2)
            {
            return Number1.Divide(Number2);
            }
        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        public static Number operator *(Number<T> Number1, T Number2)
            {
            return Number1.Multiply(Number2);
            }
        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        public static Number operator -(Number<T> Number1, T Number2)
            {
            return Number1.Subtract(Number2);
            }
        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        public static Number operator +(Number<T> Number1, T Number2)
            {
            return Number1.Add(Number2);
            }

        /// <summary>
        /// The type of number stored in the wrapper.
        /// </summary>
        public override Type NumberType => typeof(T);

        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Add(Number Value)
            {
            return this.PerformOperation(this, Value, L.Num.Operation.Add);
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Subtract(Number Value)
            {
            return this.PerformOperation(this, Value, L.Num.Operation.Subtract);
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Multiply(Number Value)
            {
            return this.PerformOperation(this, Value, L.Num.Operation.Multiply);
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Divide(Number Value)
            {
            return this.PerformOperation(this, Value, L.Num.Operation.Divide);
            }

        private Number PerformOperation(Number Number1, Number Number2, L.Num.Operation Op)
            {
            if (Number1.GetType().Name == Number2.GetType().Name && Number1 is Number<T>)
                {
                var ValueNumber1 = ((Number<T>)Number1).Value;
                var ValueNumber2 = ((Number<T>)Number2).Value;

                object Result = default(T);
                switch (Op)
                    {
                    case L.Num.Operation.Add:
                        Result = this.Add(ValueNumber1, ValueNumber2);
                        break;
                    case L.Num.Operation.Subtract:
                        Result = this.Subtract(ValueNumber1, ValueNumber2);
                        break;
                    case L.Num.Operation.Multiply:
                        Result = this.Multiply(ValueNumber1, ValueNumber2);
                        break;
                    case L.Num.Operation.Divide:
                        Result = this.Divide(ValueNumber1, ValueNumber2);
                        break;
                    }

                return L.Num.MostPreciseType.New(Result).ConvertToBestMatch();
                }
            else
                {
                var Number1Boxed = L.Num.MostPreciseType.New(Number1);
                var Number2Boxed = L.Num.MostPreciseType.New(Number2);

                Number Result = null;
                switch (Op)
                    {
                    case L.Num.Operation.Add:
                        Result = Number1Boxed.Add(Number2Boxed);
                        break;
                    case L.Num.Operation.Subtract:
                        Result = Number1Boxed.Subtract(Number2Boxed);
                        break;
                    case L.Num.Operation.Multiply:
                        Result = Number1Boxed.Multiply(Number2Boxed);
                        break;
                    case L.Num.Operation.Divide:
                        Result = Number1Boxed.Divide(Number2Boxed);
                        break;
                    }

                var BestMatch = Result.ConvertToBestMatch();

                return BestMatch;
                }
            }

        /// <summary>
        /// The smallest storable change in value for the type.
        /// </summary>
        public override Number Precision => this.TypePrecision;

        /// <summary>
        /// The lowest possible value for the type.
        /// </summary>
        public override Number MinValue => this.TypeMinValue;

        /// <summary>
        /// The highest possible value for the type.
        /// </summary>
        public override Number MaxValue => this.TypeMaxValue;

        /// <summary>
        /// The default value for the type.
        /// </summary>
        public override Number DefaultValue => this.TypeDefaultValue;

        /// <summary>
        /// The smallest storable change in value for type <typeparamref name="T"/>.
        /// </summary>
        public abstract Number<T> TypePrecision { get; }

        /// <summary>
        /// The lowest possible value for type <typeparamref name="T"/>.
        /// </summary>
        public abstract Number<T> TypeMinValue { get; }

        /// <summary>
        /// The highest possible value for type <typeparamref name="T"/>.
        /// </summary>
        public abstract Number<T> TypeMaxValue { get; }

        /// <summary>
        /// The default value for type <typeparamref name="T"/>.
        /// </summary>
        public abstract Number<T> TypeDefaultValue { get; }


        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public abstract Number<T> New(T In);

        /// <exception cref="ArgumentException">The object In is not of the correct type, and cannot be converted to it</exception>
        public override Number New([CanBeNull]object In)
            {
            if (In is T)
                return this.New((T)In);

            if (In is string && ((string)In).HasMatch(L.Num.RegexScientificNotation))
                return this.New(L.Num.ScientificNotationToNumber((string)In));

            if (In is IConvertible && ((IConvertible)In).CanConvertTo<T>())
                return this.New(((IConvertible)In).ConvertTo<T>());

            if (In is INumber)
                return this.New(((INumber)In).GetValue());

            throw new ArgumentException($"Could not create {typeof(T).Name} from {In?.GetType().Name} {In}", nameof(In));
            }


        /// <summary>
        /// Gets the underlying value
        /// </summary>
        public override object GetValue()
            {
            return this.Value;
            }


        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Add(IConvertible Value)
            {
            return this.Add(L.Num.MostPreciseType.New(Value));
            }

        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Subtract(IConvertible Value)
            {
            return this.Subtract(L.Num.MostPreciseType.New(Value));
            }

        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Multiply(IConvertible Value)
            {
            return this.Multiply(L.Num.MostPreciseType.New(Value));
            }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public override Number Divide(IConvertible Value)
            {
            return this.Divide(L.Num.MostPreciseType.New(Value));
            }



        /// <summary>
        /// Applies the addition operation and returns the result as a [T].
        /// </summary>
        public abstract T Add(T Number1, T Number2);
        /// <summary>
        /// Applies the subtraction operation and returns the result as a [T].
        /// </summary>
        public abstract T Subtract(T Number1, T Number2);
        /// <summary>
        /// Applies the multiplication operation and returns the result as a [T].
        /// </summary>
        public abstract T Multiply(T Number1, T Number2);
        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        public abstract object Divide(T Number1, T Number2);


        /// <summary>
        /// Returns a new number using the default value for the number type.
        /// </summary>
        public Number New()
            {
            return this.New(this.DefaultValue);
            }


        /// <summary>
        /// The base number object
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Create a new Number wrapper for a native number type
        /// </summary>
        protected Number()
            {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Value = ((INumber<T>)this.DefaultValue).Value;
            }

        /// <summary>
        /// Create a new Number wrapper for a native number type
        /// </summary>
        /// <param name="Value">The number value</param>
        protected Number(T Value)
            {
            this.Value = Value;
            }


        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. 
        /// The return value has these meanings: Value Meaning Less than zero This instance 
        /// precedes <paramref name="Obj" /> in the sort order. Zero This instance occurs 
        /// in the same position in the sort order as <paramref name="Obj" />. Greater than 
        /// zero This instance follows <paramref name="Obj" /> in the sort order. </returns>
        /// <param name="Obj">An object to compare with this instance. </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="Obj" /> is not the same type as this instance. </exception>
        /// <filterpriority>2</filterpriority>
        public override int CompareTo([CanBeNull] object Obj)
            {
            if (Obj is INumber)
                {
                string Str1 = this.ToString();
                string Str2 = ((INumber)Obj).ToString();

                return L.Str.CompareNumberString(Str1, Str2);
                }
            if (Obj is IComparable && Obj.GetType() == typeof(T))
                {
                return this.Value.CompareTo((IComparable)Obj);
                }
            // ReSharper disable once UseNullPropagation
            if (Obj is IConvertible)
                {
                var Result = ((IConvertible)Obj).ConvertTo(typeof(T));

                if (Result != null)
                    return this.Value.CompareTo(Result);
                }
            

            throw new ArgumentException(nameof(Obj));
            }
        }

    /// <summary>
    /// Base class for number wrappers. Provides operators for seamless mathematical operations.
    /// </summary>
    public abstract class Number : INumber
        {
        /// <summary>
        /// The type of number stored in the wrapper.
        /// </summary>
        public abstract Type NumberType { get; }
        
        /// <summary>
        /// Returns whether this Number is equal to <paramref name="Obj"/>
        /// </summary>
        public override bool Equals([CanBeNull] object Obj)
            {
            if (ReferenceEquals(null, Obj)) return false;
            if (ReferenceEquals(this, Obj)) return true;

            var Comparable = Obj as IComparable;
            if (Comparable != null)
                return this == Comparable;

            return false;
            }


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
            {
            return this.GetValue().ToString();
            }


        /// <summary>
        /// Returns whether <paramref name="Number1"/> is greater than <paramref name="Number2"/>
        /// </summary>
        public static bool operator >(Number Number1, IComparable Number2)
            {
            return Number1.IsGreaterThan(Number2);
            }
        /// <summary>
        /// Returns whether <paramref name="Number1"/> is less than <paramref name="Number2"/>
        /// </summary>
        public static bool operator <(Number Number1, IComparable Number2)
            {
            return Number1.IsLessThan(Number2);
            }
        /// <summary>
        /// Returns whether <paramref name="Number1"/> is greater than or equal to <paramref name="Number2"/>
        /// </summary>
        public static bool operator >=(Number Number1, IComparable Number2)
            {
            return Number1.IsGreaterThanOrEqual(Number2);
            }
        /// <summary>
        /// Returns whether <paramref name="Number1"/> is less than or equal to <paramref name="Number2"/>
        /// </summary>
        public static bool operator <=([CanBeNull]Number Number1, [CanBeNull]IComparable Number2)
            {
            return Number1.IsLessThanOrEqual(Number2);
            }
        /// <summary>
        /// Returns whether <paramref name="Number1"/> is equal to <paramref name="Number2"/>
        /// </summary>
        public static bool operator ==([CanBeNull]Number Number1, [CanBeNull]IComparable Number2)
            {
            if (ReferenceEquals(Number1, null) && !ReferenceEquals(Number2, null))
                return false;
            if (!ReferenceEquals(Number1, null) && ReferenceEquals(Number2, null))
                return false;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (ReferenceEquals(Number1, null) && ReferenceEquals(Number2, null))
                return true;

            return Number1.IsEqualTo(Number2);
            }
        /// <summary>
        /// Returns whether <paramref name="Number1"/> is not equal to <paramref name="Number2"/>
        /// </summary>
        public static bool operator !=([CanBeNull]Number Number1, [CanBeNull]IComparable Number2)
            {
            if (ReferenceEquals(Number1, null) && !ReferenceEquals(Number2, null))
                return true;
            if (!ReferenceEquals(Number1, null) && ReferenceEquals(Number2, null))
                return true;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (ReferenceEquals(Number1, null) && ReferenceEquals(Number2, null))
                return false;

            return Number1.IsNotEqualTo(Number2);
            }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode() => this.GetValue().GetHashCode();

        /// <summary>
        /// Performs the division operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator /([CanBeNull] Number Number1, [CanBeNull] IConvertible Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Divide(Number2);
            }

        /// <summary>
        /// Performs the division operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator /([CanBeNull]Number Number1, [CanBeNull]Number Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Divide(Number2);
            }

        /// <summary>
        /// Performs the multiplication operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator *([CanBeNull]Number Number1, [CanBeNull]IConvertible Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return new ByteNumber();

            return Number1.Multiply(Number2);
            }
        /// <summary>
        /// Performs the multiplication operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator *([CanBeNull]Number Number1, [CanBeNull]Number Number2)
            {
            if (Number1 == null)
                return new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return new ByteNumber();

            return Number1.Multiply(Number2);
            }

        /// <summary>
        /// Performs the subtraction operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator -([CanBeNull]Number Number1, [CanBeNull]IConvertible Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Subtract(Number2);
            }
        /// <summary>
        /// Performs the subtraction operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator -([CanBeNull]Number Number1, [CanBeNull]Number Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Subtract(Number2);
            }

        /// <summary>
        /// Performs the addition operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator +([CanBeNull]Number Number1, [CanBeNull]IConvertible Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Add(Number2);
            }
        /// <summary>
        /// Performs the addition operation on <paramref name="Number1"/> and <paramref name="Number2"/>.
        /// </summary>
        public static Number operator +([CanBeNull]Number Number1, [CanBeNull]Number Number2)
            {
            if (Number1 == null)
                Number1 = new ByteNumber();
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (Number2 == null)
                return Number1;

            return Number1.Add(Number2);
            }

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="Obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as 
        /// <paramref name="Obj" />. Greater than zero This instance follows <paramref name="Obj" /> in the sort order. </returns>
        /// <param name="Obj">An object to compare with this instance. </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="Obj" /> is not the same type as this instance. </exception>
        /// <filterpriority>2</filterpriority>
        public abstract int CompareTo([CanBeNull] object Obj);

        /// <summary>
        /// Create a new Number of the same type
        /// </summary>
        public abstract Number New(object In);

        /// <summary>
        /// The smallest storable change in value for the type.
        /// </summary>
        public abstract Number Precision { get; }

        /// <summary>
        /// The lowest possible value for the type.
        /// </summary>
        public abstract Number MinValue { get; }

        /// <summary>
        /// The highest possible value for the type.
        /// </summary>
        public abstract Number MaxValue { get; }

        /// <summary>
        /// The default value for the type.
        /// </summary>
        public abstract Number DefaultValue { get; }

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Divide(Number Value);

        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Multiply(Number Value);

        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Subtract(Number Value);

        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Add(Number Value);

        /// <summary>
        /// Applies the division operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        /// 
        public abstract Number Divide(IConvertible Value);

        /// <summary>
        /// Applies the multiplication operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Multiply(IConvertible Value);

        /// <summary>
        /// Applies the subtraction operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Subtract(IConvertible Value);

        /// <summary>
        /// Applies the addition operation and returns the result as a Number.
        /// </summary>
        /// <param name="Value">Number value</param>
        public abstract Number Add(IConvertible Value);

        /// <summary>
        /// Returns the precision needed to store the current value.
        /// </summary>
        public abstract Number GetValuePrecision();

        /// <summary>
        /// Gets the underlying value
        /// </summary>
        public abstract object GetValue();
        }
    }
