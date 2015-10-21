// Collatz Conjecture Length
// http://www.codewars.com/kata/54fb963d3fe32351f2000102/train/javascript

function collatz(n) {
	var result = 1;
	while (n != 1) {
		if (n % 2 === 0) {
			n = n / 2;
			result++;
		} else {
			n = (n * 3) + 1;
			result++;
		}
	}
	return result;
}

describe("Collatz Conjecture Length", function () {

	it("Tests", function () {
		Test.assertEquals(collatz(20), 8);
		Test.assertEquals(collatz(15), 18);
	});
});

// ********************************************************
// Jaden Casing Strings
//http://www.codewars.com/kata/5390bac347d09b7da40006f6/train/javascript

String.prototype.toJadenCase = function () {
	var list = this.split(' ').map(function (v) {
		return v.charAt(0).toUpperCase() + v.slice(1);
	});
	return list.join(" ");
};

describe("Jaden Casing Strings", function () {

	it("Tests", function () {
		var str = "How can mirrors be real if our eyes aren't real";
		Test.assertEquals(str.toJadenCase(), "How Can Mirrors Be Real If Our Eyes Aren't Real");
	});
});

// ********************************************************
// Digitize
// http://www.codewars.com/kata/5417423f9e2e6c2f040002ae/train/javascript

function digitize(n) {
	return String(n).split('').map(Number);
}

describe("Digitize", function () {

	it("Tests", function () {
		Test.assertSimilar(digitize(123), [1, 2, 3]);
		Test.assertSimilar(digitize(1), [1]);
		Test.assertSimilar(digitize(8675309), [8, 6, 7, 5, 3, 0, 9]);
	});
});


// ********************************************************
// Who won the election?
http://www.codewars.com/kata/554910d77a3582bbe300009c/train/javascript

function getWinner(listOfBallots) {
	var ballotResult = {}, candidates, maxSoFar = 0, winner;
	listOfBallots.map(function (value) {
		if (ballotResult[value] === undefined) {
			ballotResult[value] = 0;
		}
		ballotResult[value] = ballotResult[value] + 1;
	});
	candidates = Object.keys(ballotResult);
	for (var i = 0; i < candidates.length; i++) {
		// No need for this check. If a candidate has more than half the votes no other candidate can have the same.
		if (ballotResult[candidates[i]] === maxSoFar) {
			winner = undefined;
		}
		else if (ballotResult[candidates[i]] > maxSoFar && ballotResult[candidates[i]] > listOfBallots.length / 2) {
			maxSoFar = ballotResult[candidates[i]];
			winner = candidates[i];
		}
	}
	return winner === undefined  ? null: winner;
}

function getWinner_Better(list) {
	var result = {};
	var winNumber = list.length / 2;
	list.forEach(function (c) { ++result[c] || (result[c] = 1); });
	var answer = Object.keys(result).filter(function (key) { if (result[key] > winNumber) return key; });
	return answer[0] || null;
}

Test.describe("Who won the election", function () {
	Test.it("Test 01", function () {
		Test.assertEquals(getWinner(["A"]), "A", "\"A\" expected");
	});
	Test.it("Test 02", function () {
		Test.assertEquals(getWinner(["A", "A", "A", "B", "B", "B", "A"]), "A", "\"A\" expected");
	});
	Test.it("Test 03", function () {
		Test.assertEquals(getWinner(["A", "A", "A", "B", "B", "B"]), null, "NULL expected");
	});
	Test.it("Test 04", function () {
		Test.assertEquals(getWinner(["A", "A", "A", "B", "C", "B"]), null, "NULL expected");
	});
	Test.it("Test 05", function () {
		Test.assertEquals(getWinner(["A", "A", "B", "B", "C"]), null, "NULL expected");
	});
});


// ********************************************************
// Chain me
// http://www.codewars.com/kata/54fb853b2c8785dd5e000957/train/javascript


function chain(input, fs) {
	return chainHelper(input, fs, 0);
}

function chainHelper(input, fs, index) {
	if (index === fs.length) return input;
	return chainHelper(fs[index](input), fs, index + 1);
}

function chainBetter(v, fns) {
	return fns.reduce(function (accumulatedValue, fn) { return fn(accumulatedValue); }, v);
}

function add_chain(x) {
	return x + 10;
}

function mult(x) {
	return x * 30;
}

Test.assertEquals(chain(2, [add_chain, mult]), 360, "Error: chain function does not work");

// ********************************************************
// Count characters in your string
// http://www.codewars.com/kata/52efefcbcdf57161d4000091/train/javascript


function count(s) {
	var countMap = {};
	s.split('').forEach(function (c) {
		countMap[c] ? countMap[c]++ : countMap[c] = 1;
	});
	return countMap;
}

Test.describe("Count characters in your string", function () {
	Test.it("Test 01", function () {
		Test.assertSimilar(count("aba"), {'a': 2, 'b': 1});
	});
	Test.it("Test 02", function () {
		Test.assertSimilar(count(""), {});
	});
});

// ********************************************************
// Find the Mine!
// http://www.codewars.com/kata/528d9adf0e03778b9e00067e/train/javascript

function mineLocation(field) {
	for (var i = 0; i < field.length; i++) {
		for (var j = 0; j < field[0].length; j++) {
			if (field[i][j] === 1) {
				return [i, j];
			}
		}
	}
	return null;
}

Test.assertSimilar(mineLocation([[1, 0], [0, 0]]), [0, 0]);
Test.assertSimilar(mineLocation([[1, 0, 0], [0, 0, 0], [0, 0, 0]]), [0, 0]);
Test.assertSimilar(mineLocation([[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 1, 0], [0, 0, 0, 0]]), [2, 2]);


// ********************************************************
// Implementing Array.prototype.groupBy method
// http://www.codewars.com/kata/53c2c3e78d298dddda000460/train/javascript

Array.prototype.groupBy = function (fn) {
	var result = {};
	this.forEach(function (c) {
		if (fn === undefined) {
			result[c] ? result[c].push(c) : result[c] = [c];
		} else {
			result[fn(c)] ? result[fn(c)].push(c) : result[fn(c)] = [c];
		}
	});
	return result;
}

// Better solution:
Array.prototype.groupByBetter = function(fn) {
	fn = fn || function (x) { return x; };
  
	return this.reduce(function (result, value) {
		var key = fn(value);
		result[key] = (result[key] || []).concat(value);
		return result;
	}, {});
}

Test.assertEquals(
  JSON.stringify([1, 2, 3, 2, 4, 1, 5, 1, 6].groupBy()),
  '{"1":[1,1,1],"2":[2,2],"3":[3],"4":[4],"5":[5],"6":[6]}'
);

Test.assertEquals(
  JSON.stringify([1, 2, 3, 2, 4, 1, 5, 1, 6].groupBy(
	function (_) { return _ % 3; }
  )),
  '{"0":[3,6],"1":[1,4,1,1],"2":[2,2,5]}'
);

var words = ['one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine', 'ten'];
Test.assertEquals(
  JSON.stringify(words.groupBy(
	function (_) { return _.length; }
  )),
  '{"3":["one","two","six","ten"],"4":["four","five","nine"],"5":["three","seven","eight"]}'
);

// ********************************************************
// Throwing Darts
// http://www.codewars.com/kata/525dfedb5b62f6954d000006/train/javascript

function scoreThrows(radiuses) {
	if (radiuses.length === 0) return 0;
	var bonus = true;
	var result = radiuses.reduce(function (accu, value) {
		if (value > 10) {
			bonus = false;
		} else if (value >= 5) {
			accu += 5;
			bonus = false;
		} else {
			accu += 10;
		}
		return accu;
	}, 0);
	return bonus ? result + 100 : result;
}

Test.assertEquals(scoreThrows([1, 5, 11]), 15);
Test.assertEquals(scoreThrows([15, 20, 30]), 0);
Test.assertEquals(scoreThrows([1, 2, 3, 4]), 140);
Test.assertEquals(scoreThrows([]), 0);


// ********************************************************
// Red herring
// http://www.codewars.com/kata/55699a9664a8c14e14000161/train/csharp

function fish(input) {
	var countMap = {};
	input.forEach(function(c) {
		countMap[c] ? countMap[c]++ : countMap[c] = 1;
	});
	var singles = Object.keys(countMap).filter(function (key) { if (countMap[key] === 1) return key; });
	var multiples = Object.keys(countMap).filter(function (key) { if (countMap[key] > 1) return key; });
	return (singles.length == 1 && multiples.length >= 1) ? singles[0] : "no catch";
};

//1: 3
//"red herring": 1

Test.expect(fish([1, 1, 1, "red herring", 1]) === "red herring");
Test.expect(fish(["red herring", "red herring", "red herring"]) === "no catch");
Test.expect(fish(["red herring", "blue herring", "yellow herring"]) === "no catch");
Test.expect(fish([1, 2, 1, 2]) === "no catch");
Test.expect(fish(["red herring"]) === "no catch");


// ********************************************************
// Josephus Permutation
// http://www.codewars.com/kata/josephus-permutation

function josephus(items, k) {
	return (items.length <= 1) ? items : find_josephus(items, k, find_next_index);
}

function find_josephus(items, k, get_index_func) {
	var result = [], index = 0, orgLength = items.length, inResult = [];
	while (true) {
		index = get_index_func(items, result, index, k, inResult);
		result.push(items[index]);
		inResult[index] = true;
		if (result.length === orgLength) return result;
	}
}

function find_next_index(items, result, index, k, inResult) {
	while (true) {
		if (!inResult[index]) {
			k--;
			if (k == 0) return index;
		}
		index = (index === items.length - 1) ? 0 : index + 1;
	}
}

function josephus_better(items, k) {
	var index = 0;
	var result = [];

	while (items.length) {
		index += k - 1;
		index %= items.length;
		result.push(items.splice(index, 1)[0]);
	}
	return result;
}

// When you have a circular buffer then you don't have to manually set the index to the start. The modulus takes care of that:
// index += k - 1;
// index %= items.length;

Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 1), [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 2), [2, 4, 6, 8, 10, 3, 7, 1, 9, 5]);
Test.assertSimilar(josephus(["C", "o", "d", "e", "W", "a", "r", "s"], 4), ['e', 's', 'W', 'o', 'C', 'd', 'r', 'a']);
Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7], 3), [3, 6, 2, 7, 5, 1, 4]);
Test.assertSimilar(josephus([], 3), []);
Test.assertSimilar(josephus([1], 3), [1]);
Test.assertSimilar(josephus([1, 2, 3], 4), [1, 3, 2]);


// ********************************************************
// Stop the Zombie Apocalypse!
// http://www.codewars.com/kata/stop-the-zombie-apocalypse


function findZombies(matrix) {
	var result = matrix.map(function (row) { // fill with 0.
		return row.map(function (cell) {
			return 0;
		});
	});
	result[0][0] = 1;
	return traverse(matrix, result, 0, 0, matrix[0][0]);
}

function traverse(matrix, result, row, column, zombie) {
	var nextSteps = find_next_steps(matrix, result, row, column, zombie), nextPos;
	for (var i = 0; i < nextSteps.length; i++) {
		nextPos = nextSteps[i];
		result[nextPos[0]][nextPos[1]] = 1;
		result = traverse(matrix, result, nextPos[0], nextPos[1], zombie);
	}
	return result;
}

function find_next_steps(matrix, resultMatrix, row, column, zombie) {
	var result = [];
	if (row - 1 >= 0 && matrix[row - 1][column] === zombie && resultMatrix[row - 1][column] === 0) result.push([row - 1, column]); // up
	if (column + 1 <= matrix[0].length - 1 && matrix[row][column + 1] === zombie && resultMatrix[row][column + 1] === 0) result.push([row, column + 1]); // right
	if (row + 1 <= matrix.length - 1 && matrix[row + 1][column] === zombie && resultMatrix[row + 1][column] === 0) result.push([row + 1, column]); // down
	if (column - 1 >= 0 && matrix[row][column - 1] === zombie && resultMatrix[row][column - 1] === 0) result.push([row, column - 1]); // left
	return result;
}

// Here it is better to make all the checks in the beginning of the recursive method. Like the regular stop statement.
// Then you don't have to find out which steps are valid. You just call up, down, left, right and the stop statements
// will make sure that no invalid position are evaluated.

function findZombiesBetter(matrix) {
	var zombie_number = matrix[0][0];
	// matrix with zeros
	var bomb_map = matrix.map(function (row) {
		return row.map(function (cell) {
			return 0;
		});
	});

	function markZombies(row, col) {
		// check if position is valid
		if (!bomb_map[row]) return;
		// visited
		if (bomb_map[row][col]) return;
		// check if zombie exists here
		if (matrix[row][col] === zombie_number) {
			bomb_map[row][col] = 1;

			markZombies(row - 1, col); // up
			markZombies(row + 1, col); // down
			markZombies(row, col - 1); // left
			markZombies(row, col + 1); // right
		}
	}

	markZombies(0, 0);

	return bomb_map;
}

var exampleMatrix = [
	[8, 2, 3],
	[8, 2, 3],
	[1, 2, 8]
];

var exampleResult = [
	[1, 0, 0],
	[1, 0, 0],
	[0, 0, 0]
];

var city2 = [
	[9, 1, 2],
	[9, 9, 9],
	[7, 4, 9],
	[7, 9, 7]
];

var contaminatedInCity2 = [
	[1, 0, 0],
	[1, 1, 1],
	[0, 0, 1],
	[0, 0, 0]
]; //infection inflicted the 9s, but the virus didn't get to the one in the south of the city yet.

describe('Test Zombie maps', function () {
	it('should show zombies in 3x3 matrix', function () {
		Test.assertSimilar(findZombies(exampleMatrix), exampleResult);
	});
});

describe('Test Zombie maps', function () {
	it('should show zombies in 4x3 matrix', function () {
		Test.assertSimilar(findZombies(city2), contaminatedInCity2);
	});
});


// ********************************************************
// Movie agent
// http://www.codewars.com/kata/movie-agent


function Movie(name, start, end) {
	this.name = name;
	this.start = start;
	this.end = end;
}

function schedule(movies) {
	if (movies.length == 0) return 0;
	if (movies.length == 1) return 1;
	var sortedMovies = sortByKey(movies, "start");
	return schedule_helper(sortedMovies, 0, 0, 0);
}

function schedule_helper(movies, end, count, index) {
	if (index === movies.length) return count;
	return (movies[index].start > end)
		? Math.max(schedule_helper(movies, movies[index].end, count + 1, index + 1),
			schedule_helper(movies, end, count, index + 1))
		: schedule_helper(movies, end, count, index + 1);
}

function sortByKey(array, key) {
	return array.sort(function(a, b) {
		var x = a[key]; var y = b[key];
		return ((x < y) ? -1 : ((x > y) ? 1 : 0));
	});
}

function schedule_better(movies) {
	var result = 0,
		end = -1;
	movies.sort(function (l, r) { return l.end - r.end; });
	movies.forEach(function (m) {
		if (m.start > end) {
			end = m.end;
			result++;
		}
	});

	return result;
}
var movies = [new Movie('Java Joe', 0, 50),
			  new Movie('Looking for Clojure', 1, 5),
			  new Movie('I C you', 6, 10),
			  new Movie('Ruby Park', 11, 14)];
Test.assertEquals(schedule(movies), 3);
Test.assertEquals(schedule([]), 0);
Test.assertEquals(schedule([new Movie('Java Joe', 0, 50)]), 1);


// ********************************************************
// http://www.codewars.com/kata/54d81488b981293527000c8f/train/javascript
// Sum of pairs

var sum_pairs = function (ints, s) {
	var parsedInts = [], value;
	for (var i = 0; i < ints.length; i++) {
		value = s - ints[i];
		if (parsedInts[value]) {
			return [value, ints[i]];
		} else {
			parsedInts[ints[i]] = true;
		}
	}
	return undefined;
}

l1 = [1, 4, 8, 7, 3, 15];
l2 = [1, -2, 3, 0, -6, 1];
l3 = [20, -13, 40];
l4 = [1, 2, 3, 4, 1, 0];
l5 = [10, 5, 2, 3, 7, 5];
l6 = [4, -2, 3, 3, 4];
l7 = [0, 2, 0];
l8 = [5, 9, 13, -3];

Test.describe("Testing For Sum of Pairs", function () {
	Test.expect(sum_pairs(l1, 8) + "" == [1, 7] + "", "Basic: [" + l1 + "] should return [1, 7] for sum = 8");
	Test.expect(sum_pairs(l2, -6) + "" == [0, -6] + "", "Negatives: [" + l2 + "] should return [0, -6] for sum = -6");
	Test.expect(sum_pairs(l3, -7) == undefined, "No Match: [" + l3 + "] should return undefined for sum = -7");
	Test.expect(sum_pairs(l4, 2) + "" == [1, 1] + "", "First Match From Left: [" + l4 + "] should return [1, 1] for sum = 2 ");
	Test.expect(sum_pairs(l5, 10) + "" == [3, 7] + "", "First Match From Left REDUX!: [" + l5 + "] should return [3, 7] for sum = 10 ");
	Test.expect(sum_pairs(l6, 8) + "" == [4, 4] + "", "Duplicates: [" + l6 + "] should return [4, 4] for sum = 8");
	Test.expect(sum_pairs(l7, 0) + "" == [0, 0] + "", "Zeroes: [" + l7 + "] should return [0, 0] for sum = 0");
	Test.expect(sum_pairs(l8, 10) + "" == [13, -3] + "", "Subtraction: [" + l8 + "] should return [13, -3] for sum = 10");
});

// ********************************************************
// http://www.codewars.com/kata/54c9fcad28ec4c6e680011aa/train/javascript
// Merged String Checker

function isMerge(s, part1, part2) {
	var lastPart1Index = -1, lastPart2Index = -1, index;
	for (var i = 0; i < s.length; i++) {
		index = part1.indexOf(s[i]);
		if (index >= 0) {
			if (index >= lastPart1Index) {
				lastPart1Index = index;
				part1 = part1.slice(0, index) + part1.slice(index + 1, part1.length);
			} else {
				return false;
			}
		} else {
			index = part2.indexOf(s[i]);
			if (index >= 0) {
				if (index >= lastPart2Index) {
					lastPart2Index = index;
					part2 = part2.slice(0, index) + part2.slice(index + 1, part2.length);
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
	}
	return part1.length === 0 && part2.length === 0;
}

Test.expect(isMerge('codewars', 'code', 'wars'));
Test.expect(isMerge('codewars', 'cdw', 'oears'));
Test.expect(!isMerge('codewars', 'cod', 'wars'));
Test.expect(isMerge('Bananas from Bahamas', 'Bananas B', 'from ahamas'));

// ********************************************************
// http://www.codewars.com/kata/52b4d1be990d6a2dac0002ab/train/javascript
// Longest sequence with zero sum

var maxZeroSequence = function (arr) {
	var result = [], zeroSumIndexstart = 0, zeroSumLength = 0;
	for (var i = 0; i < arr.length; i++) {
		for (var j = 0; j <= i; j++) {
			result[j] ? result[j] = result[j] + arr[i] : result[j] = arr[i];
			if (result[j] == 0 && (i - j) > zeroSumLength) {
				zeroSumLength = i - j;
				zeroSumIndexstart = j;
			}
		}
	}
	return arr.slice(zeroSumIndexstart, zeroSumIndexstart + zeroSumLength + 1);
}

Test.assertSimilar(maxZeroSequence([25, -35, 12, 6, 92, -115, 17, 2, 2, 2, -7, 2, -9, 16, 2, -11]),
								  [92, -115, 17, 2, 2, 2]);


// ******************************************************** 
// http://www.codewars.com/kata/555615a77ebc7c2c8a0000b8/train/javascript

function tickets(peopleInLine) {
	var bill25 = 0, bill50 = 0;

	for (var i = 0; i < peopleInLine.length; i++) {
		if (peopleInLine[i] === 25) {
			bill25 += 1;
		} else if (peopleInLine[i] == 50) {
			if (bill25 > 0) {
				bill25--;
				bill50++;
			} else {
				return "NO";
			}
		} else if (bill25 > 0 && bill50 > 0) {
			bill25--;
			bill50--;
		} else if (bill25 >= 3) {
			bill25 -= 3;
		} else {
			return "NO";
		}
	}
	return "YES";
}

Test.assertEquals(tickets([25, 25, 50, 50]), "YES");
Test.assertEquals(tickets([25, 100]), "NO");
Test.assertEquals(tickets([25, 50, 100]), "NO");
Test.assertEquals(tickets([25, 50, 50]), "NO");
Test.assertEquals(tickets([25, 50, 25, 100]), "YES");
Test.assertEquals(tickets([25, 25, 25, 100, 25, 50, 25, 100, 25, 25, 25, 100]), "YES");
Test.assertEquals(tickets([25, 25, 50, 100, 25, 25, 50, 100, 25, 25, 25, 100, 25, 25, 50, 100, 25, 25, 25, 100]), "YES");


// ********************************************************
// http://www.codewars.com/kata/5326ef17b7320ee2e00001df/train/javascript
// Escape the Mines !

function solve(map, miner, exit) {
	var rute = [];
	var visited_map = map.map(function (row) {
		return row.map(function() {
			return false;
		});
	});
	solveHelper(map, miner.x, miner.y, exit, visited_map, rute);
	return rute;
}

function solveHelper(map, x, y, exit, visited_map, rute) {
	if (x === exit.x && y === exit.y) return true;

	if (map[0][y] === undefined || !map[x] || !map[x][y] || visited_map[x][y]) return false;

	visited_map[x][y] = true;

	rute.push("up");
	if (solveHelper(map, x, y - 1, exit, visited_map, rute)) return true;
	rute.splice(rute.length - 1, 1);

	rute.push("right");
	if (solveHelper(map, x + 1, y, exit, visited_map, rute)) return true;
	rute.splice(rute.length - 1, 1);

	rute.push("down");
	if (solveHelper(map, x, y + 1, exit, visited_map, rute)) return true;
	rute.splice(rute.length - 1, 1);

	rute.push("left");
	if (solveHelper(map, x - 1, y, exit, visited_map, rute)) return true;
	rute.splice(rute.length - 1, 1);

	return false;
}


describe('A trivial map (1x1)', function () {
	var map = [[true]];

	it('Should return an empty array, since we\'re already at the goal', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 0, y: 0 }), []);
	});
});

describe('A pretty simple map (2x2)', function () {
	var map = [[true, false],
	  [true, true]];

	it('Should return the only correct move', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 1, y: 0 }), ['right']);
	});

	it('Should return the only moves necessary', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 1, y: 1 }), ['right', 'down']);
	});
});

describe('A linear map(1x4)', function () {
	var map = [[true], [true], [true], [true]];

	it('Should return a chain of moves to the right', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 3, y: 0 }), ['right', 'right', 'right']);
	});

	it('Should return a chain of moves to the left', function () {
		Test.assertSimilar(solve(map, { x: 3, y: 0 }, { x: 0, y: 0 }), ['left', 'left', 'left']);
	});
});

describe('Should walk around an obstacle (3x3 map)', function () {
	var map = [[true, true, true],
	[false, false, true],
	[true, true, true]];

	it('Should return the right sequence of moves', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 2, y: 0 }), ['down', 'down', 'right', 'right', 'up', 'up']);
	});
});

describe('Should be able to change directions multiple times (5x5 map)', function () {
	var map = [[true, true, false, false, false],
	  [false, true, true, false, false],
	  [false, false, true, true, false],
	  [false, false, false, true, true],
	  [false, false, false, false, true]];

	it('Should return a step sequence of moves', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 4, y: 4 }),
		  ['down', 'right', 'down', 'right', 'down', 'right', 'down', 'right']);
	});
});

describe('Should avoid dead-ends (5x5 map)', function () {
	var map = [[true, true, true, false, true],
	  [false, false, true, false, true],
	  [true, true, true, true, true],
	  [true, false, true, false, false],
	  [false, true, true, true, true]];

	it('Should return the right moves', function () {
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 4, y: 4 }), ['down', 'down', 'right', 'right', 'right', 'right', 'down', 'down']);
	});
});

// ********************************************************
// http://www.codewars.com/kata/537400e773076324ab000262/train/javascript
// Group Anagrams

function groupAnagrams(words) {
	var map = {};
	words.forEach(function(word) {
		var sortedWord = word.split('').sort().join();
		map[sortedWord] = (map[sortedWord] || []).concat(word);
	});
	return Object.keys(map).map(function (key) { return map[key]; });
}

Test.assertSimilarUnsorted([[1, 2], [3]], [[3], [1, 2]]); // assertSimilarUnsorted is implemented by myself.
Test.assertSimilarUnsorted(groupAnagrams(["rat", "tar", "star"]), [["rat", "tar"], ["star"]]);
Test.assertSimilarUnsorted(groupAnagrams(["rat", "ok", "tar", "star", "ko"]), [["rat", "tar"], ["star"], ["ok", "ko"]]);


// ********************************************************
// http://www.codewars.com/kata/537e18b6147aa838f600001b/train/javascript
// Text align justify

var justify = function (str, len) {
	var split_words = str.split(' ');
	var lines = reformat(split_words, len);
	return lines.join('\n');
};

function reformat(words, len) {
	return reformat_helper(words, 0, len, [], [], 0);
}

function reformat_helper(words, index, len, lineList, lines, lineLength) {
	var word, gap, wordIndex;
	if (index >= words.length) {
		if (lineList.length > 0) {
			lines.push(lineList.join('').trim());
		}
		return lines;
	}

	word = words[index];
	if (lineLength + word.length <= len) {
		lineList.push(word.concat(' '));
		return reformat_helper(words, index + 1, len, lineList, lines, lineLength + word.length + 1);
	}

	if (lineList.length > 1) {
		gap = len - (lineLength - 1);
		wordIndex = 0;
		while (gap > 0) {
			lineList[wordIndex] = lineList[wordIndex].concat(' ');
			wordIndex++;
			wordIndex %= lineList.length - 1; // -1: the last word should not get any gaps.
			gap--;
		}
	}

	lines.push(lineList.join('').trim());

	return reformat_helper(words, index, len, [], lines, 0);
}

Test.assertEquals(justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 30),
						  "Lorem  ipsum  dolor  sit amet,\nconsectetur adipiscing elit.");

Test.assertEquals(justify("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sagittis dolor mauris, at elementum ligula", 15),
						  "Lorem     ipsum\ndolor sit amet,\nconsectetur\nadipiscing\nelit.\nVestibulum\nsagittis  dolor\nmauris,      at\nelementum\nligula");


// ********************************************************
// http://www.codewars.com/kata/558c04ecda7fb8f48b000075/train/javascript
// Same Array?

function same(aArr, bArr) {
	return sameHelper(aArr, bArr, containsArray, areArraysEqual);
}

function sameHelper(aArr, bArr, containsArray, areArraysEqual) {
	return aArr.length == bArr.length &&
		aArr.filter(function (x) { return containsArray(x, bArr, areArraysEqual); }).length == bArr.length;
}

function containsArray(a, b, areArraysEqual) {
	return b.some(function(elem) { return areArraysEqual(a, elem); });
}

function areArraysEqual(a, b) {
	if (a.length !== b.length) return false;
	return a.filter(function (x) { return b.indexOf(x) != -1; }).length == b.length;
}

// My solution will work with all types of objects and any number of elements in the arrays.
// Better solution since we know that the arrays always have two numbers. 
// We are therefore allowed to create a string of each array and compare these arrays.
function same(aArr, bArr) {
	var flatA = aArr.map(function (a) { return a.sort().join(''); }).sort().join('');
	var flatB = bArr.map(function (a) { return a.sort().join(''); }).sort().join('');
	return flatA === flatB;
}

describe('Simple 2x2 arrays', function () {
	it('same arrays', function () {
		Test.expect(same([[2, 5], [3, 6]], [[5, 2], [3, 6]]), "Value not what is expected for [[2,5], [3,6]] and [[5,2], [3,6]]");
		Test.expect(same([[2, 5], [3, 6]], [[6, 3], [5, 2]]), "Value not what is expected for [[2,5], [3,6]] and [[6,3], [5,2]]");
		Test.expect(same([[2, 5], [3, 6]], [[6, 3], [2, 5]]), "Value not what is expected for [[2,5], [3,6]] and [[6,3], [2,5]]");
	});
});

describe('Simple 3x3 arrays', function () {
	it('same arrays', function () {
		Test.expect(same([[2, 5], [3, 5], [6, 2]], [[2, 6], [5, 3], [2, 5]]), "Value not what is expected for [[2,5], [3,5], [6,2]] and [[2,6], [5,3], [2,5]]");
		Test.expect(same([[2, 5], [3, 5], [6, 2]], [[3, 5], [6, 2], [5, 2]]), "Value not what is expected for [[2,5], [3,5], [6,2]] and [[3,5], [6,2], [5,2]]");
	});
});

describe('Empty arrays', function () {
	it('same arrays', function () {
		Test.expect(same([], []), "Value not what is expected for [] and []");
	});
});

describe('Unequal arrays', function () {
	it('not same arrays', function () {
		Test.expect(!same([[2, 3], [3, 4]], [[4, 3], [2, 4]]), "Value not what is expected for [[2,3], [3,4]] and [[4,3], [2, 4]]");
		Test.expect(!same([[2, 3], [3, 2]], [[2, 3]]), "Value not what is expected for [[2,3], [3,2]] and [[2,3]]");
	});
});


// ********************************************************
// http://www.codewars.com/kata/547bf139ec2cf10b7c0003e6/train/javascript
// Binary search

function binSearch(arr, toSearch) {
	if (arr.length == 0) return -1;
	return binSearchHelper(arr, toSearch, 0, arr.length - 1);
}

function binSearchHelper(arr, toSearch, start, end) {
	if (start == end) return (arr[start] == toSearch) ? start : -1;
	var middleIndex = start + ((end - start) / 2)|0;
	var middleValue = arr[middleIndex];
	if (middleValue == toSearch) return middleIndex;
	return (middleValue > toSearch)
		? binSearchHelper(arr, toSearch, start, middleIndex - 1)
		: binSearchHelper(arr, toSearch, middleIndex + 1, end);
}

var arr = [1, 2, 3, 4, 5];
var arr2 = [1, 2, 3, 4];

Test.assertEquals(binSearch(arr, 6), -1);
Test.assertEquals(binSearch(arr, 2), 1);
Test.assertEquals(binSearch(arr, 1), 0);
Test.assertEquals(binSearch(arr, 5), 4);
Test.assertEquals(binSearch(arr2, 4), 3);
Test.assertEquals(binSearch(arr2, 2), 1);
Test.assertEquals(binSearch(arr2, 1), 0);
Test.assertEquals(binSearch(arr2, 5), -1);


// ********************************************************
// http://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/javascript
// Snail sort

snail = function(array) {

	var result = [];
	var trail = array.map(function(row) {
		return row.map(function(cell) {
			return false;
		});
	});

	function canMoveRight(row, col) {
		return col + 1 <= array[0].length - 1 && !trail[row][col + 1];
	}

	function canMoveDown(row, col) {
		return row + 1 <= array.length - 1 && !trail[row + 1][col];
	}

	function canMoveUp(row, col) {
		return row - 1 >= 0 && !trail[row - 1][col];
	}

	function canMoveLeft(row, col) {
		return col - 1 >= 0 && !trail[row][col - 1];
	}

	function traverse(row, col, dir) {
		if (row < 0 || row > array.length - 1) return;
		if (col < 0 || col > array[0].length - 1) return;
		if (trail[row][col]) return;

		result.push(array[row][col]);
		trail[row][col] = true;

		if (dir === "right") {
			if (canMoveRight(row, col)) {
				traverse(row, col + 1, dir);
			} else {
				traverse(row + 1, col, "down");
			}
		}

		if (dir === "down") {
			if (canMoveDown(row, col)) {
				traverse(row + 1, col, dir);
			} else {
				traverse(row, col - 1, "left");
			}
		}

		if (dir === "left") {
			if (canMoveLeft(row, col)) {
				traverse(row, col - 1, dir);
			} else {
				traverse(row - 1, col, "up");
			}
		}

		if (dir === "up") {
			if (canMoveUp(row, col)) {
				traverse(row - 1, col, dir);
			} else {
				traverse(row, col + 1, "right");
			}
		}
	}

	traverse(0, 0, "right");

	return result;
}


var snailArray1 = 
[
	[1, 2, 3],
	[4, 5, 6],
	[7, 8, 9]
];
Test.assertSimilar(snail(snailArray1), [1, 2, 3, 6, 9, 8, 7, 4, 5]);

var snailArray2 =
[
	[1, 2, 3],
	[8, 9, 4],
	[7, 6, 5]
];
Test.assertSimilar(snail(snailArray2), [1,2,3,4,5,6,7,8,9]);


// ********************************************************
http://www.codewars.com/kata/pyramid-slide-down/train/javascript
// Longest slide down

function longestSlideDown(pyramid) {
	var cache = pyramid.map(function (row) {
		return row.map(function (cell) {
			return false;
		});
	});

	function calculate(pyrymid, row, col) {
		if (row > pyramid.length - 1) return 0;
		if (col < 0 || col > pyramid[row].length - 1) return 0;
		if (row == pyramid.length - 1) return pyramid[row][col];
		if (cache[row][col] != 0) return cache[row][col];
		var downLeft = calculate(pyramid, row + 1, col);
		var downRight = calculate(pyramid, row + 1, col + 1);
		cache[row][col] = pyramid[row][col] + Math.max(downLeft, downRight);
		return cache[row][col];
	}

	return calculate(pyramid, 0, 0);
}

Test.assertEquals(longestSlideDown(
 [[3],
  [7, 4],
  [2, 4, 6],
  [8, 5, 9, 3]]),
  23, "should work for small pyramids");
Test.assertEquals(longestSlideDown(
 [[75],
  [95, 64],
  [17, 47, 82],
  [18, 35, 87, 10],
  [20, 4, 82, 47, 65],
  [19, 1, 23, 75, 3, 34],
  [88, 2, 77, 73, 7, 63, 67],
  [99, 65, 4, 28, 6, 16, 70, 92],
  [41, 41, 26, 56, 83, 40, 80, 70, 33],
  [41, 48, 72, 33, 47, 32, 37, 16, 94, 29],
  [53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14],
  [70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57],
  [91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48],
  [63, 66, 4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31],
  [4, 62, 98, 27, 23, 9, 70, 98, 73, 93, 38, 53, 60, 4, 23]]),
  1074, "should work for medium pyramids");


// ********************************************************
// http://www.codewars.com/kata/53223653a191940f2b000877/train/javascript
// Determining if a graph has a solution

function solve_graph(start, end, arcs) {
	var arcsMap = {};
	arcs.forEach(function (arc) {
		arcsMap[arc.start] ? arcsMap[arc.start].push(arc.end) : arcsMap[arc.start] = [arc.end];
	});

	function solve_graph_helper(current, endArc, map, visited) {
		var found = false, counter = 0;
		if (visited.indexOf(current) > -1) return false;
		if (current == endArc) return true;
		visited.push(current);
		while (!found && map[current] != undefined && counter < map[current].length) {
			found = solve_graph_helper(map[current][counter], endArc, map, visited);
			counter++;
		}
		return found;
	}

	return solve_graph_helper(start, end, arcsMap, []);
}

describe("Simple graph with 1 arc", function () {
	var arcs = [
	  { start: "a", end: "b" },
	]
	it("Should reach b", function () {
		Test.assertEquals(solve_graph("a", "b", arcs), true);
	});
	it("Should never reach c", function () {
		Test.assertEquals(solve_graph("a", "c", arcs), false);
	});
	it("Should reach start state", function () {
		Test.assertEquals(solve_graph("a", "a", arcs), true);
	});
});

describe("Complex graph with loops and intermediary nodes", function () {
	var arcs = [
	  { start: "a", end: "b" },
	  { start: "b", end: "c" },
	  { start: "c", end: "a" },
	  { start: "c", end: "d" },
	  { start: "e", end: "a" }
	];
	it("Should reach d", function () {
		Test.assertEquals(solve_graph("a", "d", arcs), true);
	});
	it("Should never reach nodes with no arcs leading to it", function () {
		Test.assertEquals(solve_graph("a", "e", arcs), false);
	});
	it("Should reach all nodes in a loop", function () {
		Test.assertEquals(solve_graph("a", "a", arcs), true);
		Test.assertEquals(solve_graph("a", "b", arcs), true);
		Test.assertEquals(solve_graph("a", "c", arcs), true);
	});
});


// ********************************************************
// http://www.codewars.com/kata/53e5274b68cee4114c0001ae/train/javascript
// Towers of Hanoi

function hanoi(disks) {
	
	function hanoi_helper(diskCount, from, to, inter) {
		if (diskCount == 1) return [[from, to]];
		return hanoi_helper(diskCount - 1, from, inter, to).concat([[from, to]]).concat(hanoi_helper(diskCount - 1, inter, to, from));
	}

	return hanoi_helper(disks, 1, 3, 2);
}

//Test.assertSimilar(hanoi(1), [[1, 3]]);
Test.assertSimilar(hanoi(2), [[1, 2], [1, 3], [2, 3]]);

// ********************************************************
// http://www.codewars.com/kata/did-i-finish-my-sudoku
// Did I finish my sodoku

function doneOrNot(board) {
	var i, column;
	for (i = 0; i < 8; i++) {
		if (!checkList(board[i].slice())) return "Try again!";
	}
	for (i = 0; i < 8; i++) {
		column = BuildColumnList(i);
		if (!checkList(column)) return "Try again!";
	}

	for (i = 0; i < 3; i++) {
		for (var m = 0; m < 3; m++) {
			column = buildCubeList(i, m);
			if (!checkList(column)) return "Try again!";
		}
	}

	return "Finished!";

	function BuildColumnList(index) {
		var columnList = [];
		for (var j = 0; j < 9; j++) {
			columnList.push(board[j][index]);
		}
		return columnList;
	}

	function buildCubeList(row, col) {
		var list = [];
		for (var j = 0; j < 3; j++) {
			for (var k = 0; k < 3; k++) {
				list.push(board[row * 3 + j][col * 3 + k]);
			}
		}
		return list;
	}

	function checkList(list) {
//		return list.sort().join('') == '123456789'; // This does the same as below.
		var resultList = new Array(9);
		resultList.map(function() {
			return false;
		});
		list.forEach(function(e) {
			resultList[e] = true;
		});
		for (var j = 1; j <= 9; j++) {
			if (!resultList[j]) return false;
		}
		return true;
	}
}

Test.assertEquals(doneOrNot([[5, 3, 4, 6, 7, 8, 9, 1, 2],
						 [6, 7, 2, 1, 9, 5, 3, 4, 8],
						 [1, 9, 8, 3, 4, 2, 5, 6, 7],
						 [8, 5, 9, 7, 6, 1, 4, 2, 3],
						 [4, 2, 6, 8, 5, 3, 7, 9, 1],
						 [7, 1, 3, 9, 2, 4, 8, 5, 6],
						 [9, 6, 1, 5, 3, 7, 2, 8, 4],
						 [2, 8, 7, 4, 1, 9, 6, 3, 5],
						 [3, 4, 5, 2, 8, 6, 1, 7, 9]]), "Finished!");

Test.assertEquals(doneOrNot([[5, 3, 4, 6, 7, 8, 9, 1, 2],
						 [6, 7, 2, 1, 9, 0, 3, 4, 9],
						 [1, 0, 0, 3, 4, 2, 5, 6, 0],
						 [8, 5, 9, 7, 6, 1, 0, 2, 0],
						 [4, 2, 6, 8, 5, 3, 7, 9, 1],
						 [7, 1, 3, 9, 2, 4, 8, 5, 6],
						 [9, 0, 1, 5, 3, 7, 2, 1, 4],
						 [2, 8, 7, 4, 1, 9, 6, 3, 5],
						 [3, 0, 0, 4, 8, 1, 1, 7, 9]]), "Try again!");



// ********************************************************
// http://www.codewars.com/kata/52bc74d4ac05d0945d00054e/train/javascript
// First non-repeating letter.

function firstNonRepeatingLetter(s) {
	var map = {}, nonRepeating;

	if (s.length === 0) return '';

	s.split('').forEach(function (c, index) {
		if (map[c.toUpperCase()]) {
			map[c.toUpperCase()].count++;
		} else {
			map[c.toUpperCase()] = { value: c, index: index, count: 1 };
		} 
	});

	nonRepeating = Object.keys(map)
		.map(function(m) { return map[m]; })
		.filter(function(e) { return e.count == 1; })
		.sort(function(a, b) { return a.index - b.index; })
		.slice(0, 1)[0];
	return (nonRepeating) ? nonRepeating.value : '';
}

/*
A better solution. Find all letters where the location of the first occurence is equals to the last. This will
give all non-repeating letter. Take the first. If the list is empty then return ''.

function firstNonRepeatingLetter(s) {
	var lowerCased = s.toLowerCase();
	return s.split('').filter(function (c, idx) {
		c = c.toLowerCase();
		return (lowerCased.lastIndexOf(c) === idx) && (lowerCased.indexOf(c) === idx);
	})[0] || '';
}*/


Test.describe('Simple Tests', function () {
	it('should handle simple tests', function () {
		Test.assertEquals(firstNonRepeatingLetter(''), '');
		Test.assertEquals(firstNonRepeatingLetter('a'), 'a');
		Test.assertEquals(firstNonRepeatingLetter('stress'), 't');
		Test.assertEquals(firstNonRepeatingLetter('moonmen'), 'e');
		Test.assertEquals(firstNonRepeatingLetter('sTreSS'), 'T');
		Test.assertEquals(firstNonRepeatingLetter('aaaAAaaA'), '');
		Test.assertEquals(firstNonRepeatingLetter('abcdabcd'), '');
	});
});


// ********************************************************
// http://www.codewars.com/kata/51b62bf6a9c58071c600001b/train/csharp
// Roman Numerals Encoder.

function romanNumeralEncoder(number) {
	var map = {
		1: "I", 2: "II", 3: "III", 4: "IV", 5: "V", 6: "VI", 7: "VII", 8: "VIII", 9: "IX",
		10: "X", 20: "XX", 30: "XIX", 40: "XL", 50: "L", 60: "LX", 70: "LXX", 80: "LXXX", 90: "XC",
		100: "C", 200: "CC", 300: "CCC", 400: "CD", 500: "D", 600: "DC", 700: "DCC", 800: "DCCC", 900: "CM",
		1000: "M", 2000: "MM"
	};

	return number.toString().split('').reverse()
		.map(function (x, index) {
			return x * Math.pow(10, index);
		})
		.filter(function (y) {
			return y > 0;
		})
		.reverse()
		.map(function (m) {
			return map[m];
		})
		.join('');
}

Test.assertEquals(romanNumeralEncoder(1), "I");
Test.assertEquals(romanNumeralEncoder(2), "II");
Test.assertEquals(romanNumeralEncoder(4), "IV");
Test.assertEquals(romanNumeralEncoder(707), "DCCVII");
Test.assertEquals(romanNumeralEncoder(1990), "MCMXC");
Test.assertEquals(romanNumeralEncoder(2008), "MMVIII");
Test.assertEquals(romanNumeralEncoder(1666), "MDCLXVI");

var maxSequence = function (arr) {
	var max = 0, sum = 0, value;
	for (var i = 0; i < arr.length; i++) {
		value = arr[i];
		sum = sum + value;
		if (sum < 0) {
			sum = 0;
		}
		if (sum > max) {
			max = sum;
		}
	}
	return max;
}

/*
Use of reduce.
var maxSequence = function(arr){
	var currentSum = 0;
	return arr.reduce(function(maxSum, number){
		currentSum = Math.max(currentSum+number, 0);
		return Math.max(currentSum, maxSum);
	}, 0);
}
*/

describe("maxSequence", function () {
	it("should work on an empty array", function () {
		Test.assertEquals(maxSequence([]), 0);
	});
	it("should work on the example", function () {
		Test.assertEquals(maxSequence([-2, 1, -3, 4, -1, 2, 1, -5, 4]), 6);
	});
});
