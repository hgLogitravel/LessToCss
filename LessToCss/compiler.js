const path = require('path');
const fs = require('fs');
const less = require('less');


/**
 * Wrapper to compile Less  for .NET NodeServices
 * @param {string} filePath Less file path
 * @param {Function} callback function(error, result)
 */
module.exports = function compileLess(callback, filePath) {
    // Set the paths relative to the less file in order to resolve imports
    const config = {
        'path': [path.dirname(filePath)],
        'filename': filePath,
    };

    let content;
    try {
        content = readFile(filePath);
    } catch(error) {
        return callback(error, {});
    }

    less.render(content, config)
        .then(result => callback(false, result))
        .catch(error => callback(error, {}));
}


function readFile(filePath) {
    filePath = path.resolve(process.cwd(), filePath);
    const content = fs.readFileSync(filePath, 'utf8');
    // remove BOM character
    return content.replace(/^\uFEFF/, '');
}