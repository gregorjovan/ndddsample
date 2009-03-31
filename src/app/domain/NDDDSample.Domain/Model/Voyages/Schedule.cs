﻿namespace NDDDSample.Domain.Model.Voyages
{
    #region Usings

    using System.Collections.Generic;
    using JavaRelated;
    using Shared;

    #endregion

    /// <summary>
    /// A voyage schedule.
    /// </summary>
    public class Schedule : IValueObject<Schedule>
    {
        public static readonly Schedule EMPTY = new Schedule();
        private readonly List<CarrierMovement> carrierMovements = new List<CarrierMovement>();

        #region Constr

        internal Schedule(List<CarrierMovement> carrierMovements)
        {
            Validate.notNull(carrierMovements);
            Validate.noNullElements(carrierMovements);
            Validate.notEmpty(carrierMovements);

            this.carrierMovements = carrierMovements;
        }

        private Schedule()
        {
            // Needed by Hibernate
        }

        #endregion

        #region IValueObject<Schedule> Members

        /// <summary>
        /// Value objects compare by the values of their attributes, they don't have an identity.
        /// </summary>
        /// <param name="other">The other value object.</param>
        /// <returns>true if the given value object's and this value object's attributes are the same.</returns>
        public bool SameValueAs(Schedule other)
        {
            return other != null && carrierMovements.Equals(other.carrierMovements);
        }

        #endregion

        /// <summary>
        /// Carrier movements.
        /// </summary>
        public IList<CarrierMovement> CarrierMovements
        {
            get { return new List<CarrierMovement>(carrierMovements).AsReadOnly(); }
        }

        #region Object's override

        public override bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }
            if (o == null || GetType() != o.GetType())
            {
                return false;
            }

            var that = (Schedule) o;

            return SameValueAs(that);
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder().Append(carrierMovements).ToHashCode();
        }

        #endregion

    }
}