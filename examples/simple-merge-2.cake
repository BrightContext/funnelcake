INPUT in1;
INPUT in2;
OUTPUT out;

out = MERGE in1, in2
      WITH (in1.a, in2.a) AS a,
           (in1.b, true)  AS b,
           (in1.c, in2.x) AS term;
