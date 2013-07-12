INPUT in1;
OUTPUT out;

stream1 = FILTER in1 WHERE a == "hello";

out = FILTER stream1 WHERE b == "world";

