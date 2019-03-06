module.exports = {
    entry: "src/App.fsproj",
    outDir: "out",
    babel: {
        "plugins": ["@babel/plugin-transform-modules-commonjs"]
    }
  }