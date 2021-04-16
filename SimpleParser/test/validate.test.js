import {validate} from '../lib/main.js';

const good = '([((({()})))])';
const missingClose = '([((({()}))))';
const truncated = '([((({()})))]';

test('good', () => {
    expect(validate(good)).toBe(true);
});

test('missing close', () => {
    expect(validate(missingClose)).toBe(false);
});

test('truncated', () => {
    expect(validate(truncated)).toBe(false);
});
