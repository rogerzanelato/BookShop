const truncateText = (text, maxSize) => {
  return text.length > maxSize ? text.substr(0, maxSize) + "..." : text;
};

export { truncateText };
