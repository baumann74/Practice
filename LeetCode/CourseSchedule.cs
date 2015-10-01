using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
	// https://leetcode.com/problems/course-schedule/

	public class CourseSchedule
	{
		private Node[] nodes;

		public bool CanFinish(int numCourses, int[,] prerequisites)
		{
			nodes = new Node[numCourses].Select(x => new Node()).ToArray();
			for (var i = 0; i < prerequisites.Length; i++)
			{
				nodes[prerequisites[i, 0]].Outgoing.Add(prerequisites[i, 1]);
				nodes[prerequisites[i, 1]].Incoming.Add(prerequisites[i, 0]);
			}
			var unMarkedNode = nodes.FirstOrDefault(x => !x.HasMark);
			var hasCycle = false;
			while (unMarkedNode != null && !hasCycle)
			{
				hasCycle = Visit(unMarkedNode);
				unMarkedNode = nodes.FirstOrDefault(x => !x.HasMark);
			}
			return hasCycle;
		}

		private bool Visit(Node node)
		{
			if (node.HasTempMark) return true;
			if (node.HasMark) return false;
			var result = node.Outgoing.Aggregate(false, (current, sibling) => current || Visit(nodes[sibling]));
			node.HasMark = true;
			node.HasTempMark = false;
			return result;
		}

		private class Node
		{
			public List<int> Outgoing { get; set; }
			public bool HasTempMark { get; set; }
			public bool HasMark { get; set; }
			public List<int> Incoming { get; set; }

			public Node()
			{
				Outgoing = new List<int>();
				Incoming = new List<int>();
			}
		}
	}
}
