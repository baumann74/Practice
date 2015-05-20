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
	list.forEach(function (char) { ++result[char] || (result[char] = 1); });
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