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

function add(x) {
	return x + 10;
}

function mult(x) {
	return x * 30;
}

Test.assertEquals(chain(2, [add, mult]), 360, "Error: chain function does not work");

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
		Test.assertSimilar(solve(map, { x: 0, y: 0 }, { x: 4, y: 4 }), ['down', 'down', 'right', 'right', 'right', 'right', 'down', 'down'])
	});
});
