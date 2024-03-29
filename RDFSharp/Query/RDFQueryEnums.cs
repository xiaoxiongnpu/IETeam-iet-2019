﻿/*
   Copyright 2012-2019 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace RDFSharp.Query
{

    /// <summary>
    /// RDFQueryEnums represents a collector for all the enumerations used by the "RDFSharp.Query" namespace
    /// </summary>
    public static class RDFQueryEnums
    {

        /// <summary>
        /// RDFPatternHoles represents an enumeration for possible positions of holes in a pattern.
        /// </summary>
        internal enum RDFPatternHoles { C, S, P, O, CS, CP, CO, CSP, CSO, CPO, CSPO, SP, SO, PO, SPO };

        /// <summary>
        /// RDFOrderByFlavors represents an enumeration for possible directions of query results ordering on a given variable.
        /// </summary>
        public enum RDFOrderByFlavors
        {
            /// <summary>
            /// Orders SPARQL results in ascending mode on the selected variable
            /// </summary>
            ASC = 1,
            /// <summary>
            /// Orders SPARQL results in descending mode on the selected variable
            /// </summary>
            DESC = 2
        };

        /// <summary>
        /// RDFAggregatorFunctionTypes represents an enumeration for supported types of aggregator functions
        /// </summary>
        public enum RDFAggregatorFunctionTypes
        {
            /// <summary>
            /// Aggregator function which calculates the average value of the in-scope variable
            /// </summary>
            AVG = 1,
            /// <summary>
            /// Aggregator function which calculates the minimum value of the in-scope variable
            /// </summary>
            MIN = 2,
            /// <summary>
            /// Aggregator function which calculates the maximum value of the in-scope variable
            /// </summary>
            MAX = 3,
            /// <summary>
            /// Aggregator function which calculates the count of occurrences of the in-scope variable
            /// </summary>
            COUNT = 4,
            /// <summary>
            /// Aggregator function which calculates the sum value of the in-scope variable
            /// </summary>
            SUM = 5
        }

        /// <summary>
        /// RDFComparisonFlavors represents an enumeration for possible comparison modes between two patten members.
        /// </summary>
        public enum RDFComparisonFlavors
        {
            /// <summary>
            /// Represents the less-or-equal comparison operator
            /// </summary>
            LessOrEqualThan = 1,
            /// <summary>
            /// Represents the less comparison operator
            /// </summary>
            LessThan = 2,
            /// <summary>
            /// Represents the equal comparison operator
            /// </summary>
            EqualTo = 3,
            /// <summary>
            /// Represents the not-equal comparison operator
            /// </summary>
            NotEqualTo = 4,
            /// <summary>
            /// Represents the greater comparison operator
            /// </summary>
            GreaterThan = 5,
            /// <summary>
            /// Represents the greater-or-equal comparison operator
            /// </summary>
            GreaterOrEqualThan = 6
        };

        /// <summary>
        /// RDFPropertyPathStepFlavors represents an enumeration for possible connection types within a property path.
        /// </summary>
        public enum RDFPropertyPathStepFlavors
        {
            /// <summary>
            /// Steps within a property path are connected with AND semantic
            /// </summary>
            Sequence = '/',
            /// <summary>
            /// Steps within a property path are connected with OR semantic
            /// </summary>
            Alternative = '|'
        }

    }

}