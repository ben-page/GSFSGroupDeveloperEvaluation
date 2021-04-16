import {parse} from '../lib/main.js';

const good = '([((({()})))])';
const missingClose = '([((({()}))))';
const truncated = '([((({()})))]';

test('good', () => {
    expect(() => {
        parse(good)
    }).not.toThrow();
});

test('missing close', () => {
    expect(() => {
        parse(missingClose)
    }).toThrow(new Error('Unexpected token ) at position 12'));
});

test('truncated', () => {
    expect(() => {
        parse(truncated)
    }).toThrow(new Error('Unexpected end of string'));
});
