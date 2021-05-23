using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Graph.MatrixGraph
{
    public class Example
    {
        // 0:---------------------------[0]
        //                           *       *
        // 1:------------------[1]--------------[2]
        //                   *  *  *    
        //                *     *     *
        //             *        *        *          
        // 2:-------[3]----*---[4]---------[6]         
        //                      *         *   *
        //                      *       *       *
        // 3:------------------[5]----[7]--------[8]
        //
        public Example()
        {
            var g = new MyGraph(9);
            Console.Write("\n-----\nGraph:\n");
            g.InsertVertex(0, 1);
            g.InsertVertex(0, 2);
            g.InsertVertex(1, 3);
            g.InsertVertex(1, 4);
            g.InsertVertex(1, 6);
            g.InsertVertex(3, 4);
            g.InsertVertex(4, 5);
            g.InsertVertex(6, 7);
            g.InsertVertex(6, 8);
            Deep(g);
            Width(g);
        }

        private void Deep(MyGraph g)
        {
            // -> [ 0 -> 1 ] -> [ 1 -> 3 ] -> [ 3 -> 4 ] -> [ 4 -> 5 ] 
            //                      -> ( exit from vertex:5 ) 
            //          -> ( return to vertex:4 ) 
            //                      -> ( exit from vertex:4 ) 
            //          -> ( return to vertex:3 ) 
            //                      -> ( exit from vertex:3 ) 
            //          -> ( return to vertex:1 ) 
            // -> [ 1 -> 6 ] -> [ 6 -> 7 ] 
            //                      -> ( exit from vertex:7 ) 
            //          -> ( return to vertex:6 ) 
            // -> [ 6 -> 8 ] 
            //                      -> ( exit from vertex:8 ) 
            //          -> ( return to vertex:6 ) 
            //                      -> ( exit from vertex:6 ) 
            //          -> ( return to vertex:1 ) 
            //                      -> ( exit from vertex:1 )
            //          -> ( return to vertex:0 )
            // -> [ 0 -> 2 ] 
            //                      -> ( exit from vertex:2 )
            //          -> ( return to vertex:0 )
            //                      -> ( exit from vertex:0 ) ->
            Console.Write("\nTrasversal deep:\n");
            g.TraversalDeep(0);
        }

        private void Width(MyGraph g)
        {
            Console.Write("\nTrasversal width:\n");
            g.TraversalWidth(3);
        }

    }
}
