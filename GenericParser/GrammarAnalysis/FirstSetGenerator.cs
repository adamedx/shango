using System;
using System.Collections;
using GraphTheory;
using GraphTheory.Representation.AdjacencyList;
using GraphTheory.Algorithms;

namespace GenericParser.GrammarAnalysis
{
	/// <summary>
	/// Summary description for FirstSetcs.
	/// </summary>
    public class FirstSetGenerator
    {
        public FirstSetGenerator( Grammar grammar )
        {
            _grammar = grammar;
        }

        public
            Hashtable
            GenerateFirstSets()
        {
            Production[] productions = _grammar.Rules;

            Hashtable sets = new Hashtable();

            foreach( Production rule in productions )
            {
                sets.Add( rule.Left.Name, new FirstSet( rule.Left ) );
            }

            MarkNullable( sets );

            IGraph firstGraph = CreateFirstLevelGraph( sets );

            IGraph closureGraph = ComputeReflexiveTransitiveClosure( firstGraph );

            GenerateFirstSetsFromReachableTerminals(
                closureGraph );

            return sets;            
        }                   

        void
            MarkNullable(
            Hashtable sets )
        {
            MarkNonterminalsWithEmptyProductions( sets );

            int markedNonterminals = 0;

            do
            {
                markedNonterminals = MarkNonterminalsWithNullableProductions( sets );
            }
            while ( markedNonterminals > 0 );
        }

        void
            MarkNonterminalsWithEmptyProductions(
            Hashtable sets )
        {
            Production[] productions = _grammar.Rules;
            
            foreach( Production rule in productions )
            {
                if ( ( 1 == rule.Right.Count ) &&
                    ( Terminal.Empty == rule.Right[0] ) )
                {
                    ( (FirstSet) sets[ rule.Left ]).AddSymbol( Terminal.Empty );
                }
            }
        }

        int
            MarkNonterminalsWithNullableProductions(
            Hashtable sets )
        {
            int markedNonterminals = 0;

            Production[] productions = _grammar.Rules;
            
            foreach( Production rule in productions )
            {
                FirstSet ruleSet = (FirstSet) sets[ rule.Left ];

                if ( ruleSet.HasEmpty )
                {
                    continue;
                }

                bool allNonterminalsNullable = true;
                bool hasNonterminal = false;

                foreach( ProductionElement element in rule.Right )
                {
                    if ( element is NonTerminal )
                    {
                        hasNonterminal = true;

                        FirstSet rightSet = (FirstSet) sets[ element ];

                        if ( ! rightSet.HasEmpty )
                        {
                            allNonterminalsNullable = false;
                        }
                    }
                }

                if ( allNonterminalsNullable && hasNonterminal )
                {
                    ruleSet.AddSymbol( Terminal.Empty );
                    markedNonterminals++;
                }
            }

            return markedNonterminals;
        }

        IGraph
            CreateFirstLevelGraph(
            Hashtable sets )
        {
            ListGraph firstLevelGraph = new ListGraph();

            Vertex emptyVertex = firstLevelGraph.AddVertex( Terminal.Empty );

            foreach ( object setObject in sets )
            {
                FirstSet firstSet = (FirstSet) setObject;

                Vertex nonTerminal = firstLevelGraph.AddVertex( firstSet );

                if ( firstSet.HasEmpty )
                {
                    firstLevelGraph.AddEdge(                        
                        nonTerminal,
                        emptyVertex );
                }
            }

            return firstLevelGraph;
        }

        IGraph
            ComputeReflexiveTransitiveClosure(
            IGraph firstGraph )
        {
            Closure closureComputer = new Closure( firstGraph );

            ListGraph closureGraph = new ListGraph( firstGraph );

            closureComputer.ReflexiveTransitive();

            return closureGraph;
        }

        void
            GenerateFirstSetsFromReachableTerminals(
            IGraph     firstGraph )
        {
            foreach( Vertex firstSetVertex in firstGraph.Vertices )
            {
                FirstSet firstSet = (FirstSet) firstSetVertex.Key;

                ArrayList edgesFrom = firstGraph.GetEdgesFrom( firstSetVertex );

                foreach( Edge exitEdge in edgesFrom )
                {
                    firstSet.AddSymbol( (Terminal) (exitEdge.Sink.Key) );
                }
            }
        }

        Grammar _grammar;
	}
}
