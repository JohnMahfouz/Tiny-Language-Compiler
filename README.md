# 🧠 TinyCompiler

TinyCompiler is a simple lexical analyzer (scanner) for a custom programming language, written in C#. It reads source code, identifies lexemes, and categorizes them into tokens such as identifiers, keywords, operators, and literals.

## 📄 Documentation

- 📘 [Regex](./Tiny_Language_DFA_NFA.pdf)
- 📗 [Context free grammar](./Tiny_Language_CFG.pdf)

## 🚀 Features

- Tokenizes source code into structured tokens.
- Supports:
  - Arithmetic operators (`+`, `-`, `*`, `/`)
  - Logical operators (`&&`, `||`, `<`, `>`, `=`, `<>`)
  - Delimiters and punctuation (`{`, `}`, `(`, `)`, `,`, `;`)
  - Keywords (`if`, `else`, `read`, `write`, etc.)
  - Identifiers and literals (numbers, strings)
- Handles comments (`/* comment */`)
- Tracks line numbers and basic error handling (e.g., unexpected tokens, unterminated strings/comments).

## 🛠️ How It Works

1. The `Scanner` reads the source code character by character.
2. It matches known patterns (operators, keywords, identifiers, numbers).
3. It stores matched lexemes as `Token` objects with type and value.
4. Errors (e.g., invalid lexemes or unterminated strings/comments) are collected by line number.

## ✅ Sample Keywords Supported

- `int`, `float`, `string`
- `if`, `elseif`, `else`, `then`, `end`
- `read`, `write`, `repeat`, `until`, `return`, `main`
