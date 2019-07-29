/**
 * Truncate a text to the given max size, if needed
 * @param {*} text
 * @param {*} maxSize
 */
const truncateText = (text, maxSize) => {
  return text.length > maxSize ? text.substr(0, maxSize) + "..." : text;
};

export { truncateText };
