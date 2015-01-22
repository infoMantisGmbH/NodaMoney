﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodaMoney
{
    /// <summary>Represents Money, an amount defined in a specific Currency.</summary>
    public partial struct Money
    {
        /// <summary>Adds two specified <see cref="Money"/> values.</summary>
        /// <param name="money1">The first <see cref="Money"/> object.</param>
        /// <param name="money2">The second <see cref="Money"/> object.</param>
        /// <returns>A <see cref="Money"/> object with the values of both <see cref="Money"/> objects added.</returns>
        public static Money Add(Money money1, Money money2)
        {
            AssertIsSameCurrency(money1, money2);
            return new Money(decimal.Add(money1.Amount, money2.Amount), money1.Currency);
        }

        /// <summary>Subtracts one specified <see cref="Money"/> value from another.</summary>
        /// <param name="money1">The first <see cref="Money"/> object.</param>
        /// <param name="money2">The second <see cref="Money"/> object.</param>
        /// <returns>A <see cref="Money"/> object where the second <see cref="Money"/> object is subtracted from the first.</returns>
        public static Money Subtract(Money money1, Money money2)
        {
            AssertIsSameCurrency(money1, money2);
            return new Money(decimal.Subtract(money1.Amount, money2.Amount), money1.Currency);
        }

        /// <summary>Multiplies the specified money.</summary>
        /// <param name="money">The money.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>The result as <see cref="Money"/> after multiplying.</returns>
        public static Money Multiply(Money money, decimal multiplier)
        {
            return new Money(decimal.Multiply(money.Amount, multiplier), money.Currency);
        }

        /// <summary>Divides the specified money.</summary>
        /// <param name="money">The money.</param>
        /// <param name="divisor">The divider.</param>
        /// <returns>The division as <see cref="Money"/>.</returns>
        /// <remarks>This division can lose money! Use <seealso cref="SafeDivide"/> to do a safe division.</remarks>
        public static Money Divide(Money money, decimal divisor)
        {
            return new Money(decimal.Divide(money.Amount, divisor), money.Currency);
        }

        /// <summary>Divides the specified money.</summary>
        /// <param name="money1">The money.</param>
        /// <param name="money2">The divider.</param>
        /// <returns>The <see cref="System.Decimal"/> result of dividing left with right.</returns>
        /// <remarks>Division of Money by Money, means the unit is lost, so the result will be Decimal.</remarks>
        public static decimal Divide(Money money1, Money money2)
        {
            AssertIsSameCurrency(money1, money2);
            return decimal.Divide(money1.Amount, money2.Amount);
        }

        ///// <summary>Increments the specified money.</summary>
        ///// <param name="left">The left.</param>
        ///// <param name="right">The right.</param>
        ///// <returns>The incremented money.</returns>
        ////public static Money Increment(Money left, Money right)
        ////{
        ////    return left + right;
        ////}

        ///// <summary>Decrements the specified money.</summary>
        ///// <param name="left">The left.</param>
        ///// <param name="right">The right.</param>
        ///// <returns>The decremented money.</returns>
        ////public static Money Decrement(Money left, Money right)
        ////{
        ////    return left - right;
        ////}

        /// <summary>Adds two specified <see cref="Money"/> values.</summary>
        /// <param name="left">A <see cref="Money"/> object on the left side.</param>
        /// <param name="right">A <see cref="Money"/> object on the right side.</param>
        /// <returns>The <see cref="Money"/> result of adding left and right.</returns>
        public static Money operator +(Money left, Money right)
        {
            return Money.Add(left, right);
        }

        /// <summary>Subtracts two specified <see cref="Money"/> values.</summary>
        /// <param name="left">A <see cref="Money"/> object on the left side.</param>
        /// <param name="right">A <see cref="Money"/> object on the right side.</param>
        /// <returns>The <see cref="Money"/> result of subtracting right from left.</returns>
        public static Money operator -(Money left, Money right)
        {
            return Money.Subtract(left, right);
        }

        /// <summary>Multiplies the <see cref="Money"/> value by the given value.</summary>
        /// <param name="left">A <see cref="Money"/> object on the left side.</param>
        /// <param name="right">A <see cref="System.Decimal"/> object on the right side.</param>
        /// <returns>The <see cref="Money"/> result of multiplying right with left.</returns>
        public static Money operator *(Money left, decimal right)
        {
            return Money.Multiply(left, right);
        }

        /// <summary>Multiplies the <see cref="Money"/> value by the given value.</summary>
        /// <param name="left">A <see cref="System.Decimal"/> object on the left side.</param>
        /// <param name="right">A <see cref="Money"/> object on the right side.</param>
        /// <returns>The <see cref="Money"/> result of multiplying left with right.</returns>
        public static Money operator *(decimal left, Money right)
        {
            return Money.Multiply(right, left);
        }

        /// <summary>Divides the <see cref="Money"/> value by the given value.</summary>
        /// <param name="left">A <see cref="Money"/> object on the left side.</param>
        /// <param name="right">A <see cref="System.Decimal"/> object on the right side.</param>
        /// <returns>The <see cref="Money"/> result of dividing left with right.</returns>
        /// <remarks>This division can lose money! Use <seealso cref="SafeDivide"/> to do a safe division.</remarks>
        public static Money operator /(Money left, decimal right)
        {
            return Money.Divide(left, right);
        }

        /// <summary>Divides the <see cref="Money"/> value by the given value.</summary>
        /// <param name="left">A <see cref="Money"/> object on the left side.</param>
        /// <param name="right">A <see cref="Money"/> object on the right side.</param>
        /// <returns>The <see cref="System.Decimal"/> result of dividing left with right.</returns>
        /// <remarks>Division of Money by Money, means the unit is lost, so the result will be Decimal.</remarks>
        public static decimal operator /(Money left, Money right)
        {
            return Money.Divide(left, right);
        }

        ///// <summary>Implements the operator ++.</summary>
        ///// <param name="money">The money.</param>
        ///// <returns>The result of the operator.</returns>
        ////public static Money operator ++(Money money)
        ////{
        //// TODO: Create in Currency lowest cent value and use this. Not here: it's not responsiblity of money
        ////    decimal minValue = Math.Pow(10M, -1M * money.Currency.DecimalDigits);
        ////    return money + new Money(money.Currency, minValue);
        ////}

        ///// <summary>
        ///// Implements the operator --.
        ///// </summary>
        ///// <param name="money">The money.</param>
        ///// <returns>The result of the operator.</returns>
        ////public static Money operator --(Money money)
        ////{
        ////    double minValue = Math.Pow(10, -1 * money.Currency.DecimalDigits);
        ////    return money - new Money(money.Currency, minValue);
        ////}
    }
}