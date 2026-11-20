Zavier Zan Mini Project

A path-finding algorithm known as A*. A small project is displaying a way the computer searches the end from the endpoint. This code is focused on the algorithm with minimum graphics. The path-finding may be able to improve to achieve the result in a smaller time frame.


A* algorithm uses the advantage of Dijkstra's algorithm [the use of g(n), the cost from the start node to current node n] and Greedy Best First Search [the use of h(n), the estimated cost to reach the end node from current node n]. A* is typically faster than Dijkstra and more accurate in finding the shortest route than Greedy Best. 


Time Complexity of A*
	O(b^d)
	Θ(d)
	Ω(n^2)
where; 	b = average number of neighbour per node, 
	d = numbers of steps along the shortest route,
	n = size of the graph


A* algorithm is used in predicting the shortest route on Google Maps. It is also used for monster path-finding toward the player or object in games.