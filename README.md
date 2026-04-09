# Codey C# Tutor

A Visual Studio extension that teaches you C# from inside the IDE.

## Features

- 52 exercises (Beginner → Intermediate → Advanced)
- AI hints via local Ollama — no API key needed
- Live code review as you type
- Compile & run code directly in the panel
- Progress tracking saved to disk

## Requirements

- Visual Studio 2022
- [Ollama](https://ollama.com) running locally

## Ollama Setup

Install Ollama from https://ollama.com, then run:

```bash
ollama pull qwen2.5-coder:7b
ollama serve
```

## Usage

Open the Codey tool window in VS, pick an exercise, write your code, and hit Run. Use the Hint button if you get stuck.
