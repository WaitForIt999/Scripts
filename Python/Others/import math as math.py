import math as math
import cmath as cmath


calculator = {
    'add': lambda x, y: x + y,
    'subtract': lambda x, y: x - y,
    'multiply': lambda x, y: x * y,
    'divide': lambda x, y: x / y if y != 0 else 'Division by zero error',
    'sqrt': lambda x: x ** 0.5 if x >= 0 else 'Square root of negative number error',
    'power': lambda x, y: x ** y,
    'sin': lambda x: math.sin(x),
    'cos': lambda x: math.cos(x),
    'tan': lambda x: math.tan(x),
}

def factorial(x):
    if x < 0:
        return 'Factorial of negative number error'
    if x == 0:
        return 1
    return x * factorial(x - 1)

calculator['factorial'] = factorial

def power(x, y):
    return x ** y

def calculate(operation, *args):
    if operation in calculator:
        return calculator[operation](*args)
    else:
        return 'Operation not supported'
# Example usage:

print(calculate({'operation': 'add', 'args': (5, 3)}['operation'], *{'operation': 'add', 'args': (5, 3)}['args']))  # Output: 8
print(calculate({'operation': 'sqrt', 'args': (16,)}['operation'], *{'operation': 'sqrt', 'args': (16,)}['args']))  # Output: 4.0
