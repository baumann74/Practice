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

Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 1), [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 2), [2, 4, 6, 8, 10, 3, 7, 1, 9, 5]);
Test.assertSimilar(josephus(["C", "o", "d", "e", "W", "a", "r", "s"], 4), ['e', 's', 'W', 'o', 'C', 'd', 'r', 'a']);
Test.assertSimilar(josephus([1, 2, 3, 4, 5, 6, 7], 3), [3, 6, 2, 7, 5, 1, 4]);
Test.assertSimilar(josephus([], 3), []);
Test.assertSimilar(josephus([1], 3), [1]);
Test.assertSimilar(josephus([1, 2, 3], 4), [1, 3, 2]);


// ********************************************************
// Movie agent
// http://www.codewars.com/kata/movie-agent