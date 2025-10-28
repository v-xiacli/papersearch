function greet(name: string): string {
  return `Hello, ${name}!`;
}

const message: string = greet("World");
console.log(message);

function add(a: number, b: number, ...rest: number[]) {
  return a + b + rest.reduce((p, c) => p + c, 0);
}
