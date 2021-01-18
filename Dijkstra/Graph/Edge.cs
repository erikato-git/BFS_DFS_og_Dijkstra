﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Edge<T>
    {   
        /// <summary>
        /// Region that contains all variables
        /// </summary>
        #region Variables

        private Node<T> from; //Starting point of the edge

        private Node<T> to; //Endpoint of the edge

        private double km;

        #endregion

        /// <summary>
        /// Region that contains all peoperties
        /// </summary>
        #region Propterties

        public double Km
        {
            get { return km; }
            set { km = value; }
        }

        public Node<T> To
        {
            get { return to; }
            set { to = value; }
        }

        public Node<T> From
        {
            get { return from; }
            set { from = value; }
        }

        #endregion

        /// <summary>
        /// The edge's constructor
        /// </summary>
        /// <param name="From">The edge's starting node</param>
        /// <param name="To">The edge's endnode</param>
        public Edge(Node<T> From, Node<T> To, double km)
        {
            from = From;
            to = To;
            this.km = km;
        }


        /// <summary>
        /// Converts the edge to at string between to nodes
        /// </summary>
        /// <returns>String representation of the edge</returns>
        public override string ToString()
        {
            return String.Format("{0}->{1}, km: {2}", from.ToString(), to.ToString(), km.ToString());
        }
    }
}
