const types = Object.freeze({
    Brace: 1,
    Bracket: 2,
    Parenthesis: 3,
    Other: 4
});

/**
 * Represents a Node in the Syntax Tree
 */
class Node {
    constructor(parent, type, start) {
        this.Parent = parent;
        this.start = start;
        this.end = undefined;
        this.type = type;
        this.nodes = [];
    }

    Append(node) {
        this.nodes.push(node);
    }

    Close(end) {
        this.end = end;
    }
}

/**
 * A simple expression parser that only handles parenthesis, brackets, and braces
 */
class SimpleParser {
    constructor() {
        this.Root = undefined;
        this._currentNode = undefined;
    }

    Parse(code) {
        for (let i = 0; i < code.length; i++) {
            const char = code.charAt(i);
            switch (char) {
                case '{':
                    this._append(types.Brace, i);
                    break;
                case '}':
                    if (this._currentNode.type !== types.Brace)
                        throw new Error(`Unexpected token ${char} at position ${i}`);

                    this._close(i);
                    break;

                case '[':
                    this._append(types.Bracket, i);
                    break;
                case ']':
                    if (this._currentNode.type !== types.Bracket)
                        throw new Error(`Unexpected token ${char} at position ${i}`);

                    this._close(i);
                    break;

                case '(':
                    this._append(types.Parenthesis, i);
                    break;
                case ')':
                    if (this._currentNode.type !== types.Parenthesis)
                        throw new Error(`Unexpected token ${char} at position ${i}`);

                    this._close(i);
                    break;
            }
        }

        if (this._currentNode)
            throw new Error("Unexpected end of string")
    }

    _append(type, start) {
        const node = new Node(this._currentNode, type, start);

        if (!this.Root)
            this.Root = node;

        if (this._currentNode)
            this._currentNode.Append(node);

        this._currentNode = node;
    }

    _close(end) {
        this._currentNode.Close(end);
        this._currentNode = this._currentNode.Parent;
    }
}

export function parse(code) {
    const parser = new SimpleParser();
    return parser.Parse(code);
}

export function validate(code) {
    try {
        const parser = new SimpleParser();
        parser.Parse(code);
        return true;
    } catch (ex) {
        return false;
    }
}
