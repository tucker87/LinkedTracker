const { src, dest, watch, parallel } = require('gulp')
const browserify = require('browserify')
const vueify = require('vueify')
const babelify = require('babelify')
const source = require('vinyl-source-stream')
const babel = require('gulp-babel')

const distDir = './LinkedTracker.UI/wwwroot/dist/'

const copy = () =>
    src('./node_modules/jt.js/t.js')
        .pipe(babel({ "presets": ["@babel/preset-env"] }))
        .pipe(dest(distDir))

const bundle = () =>
    browserify({ entries: ['./LinkedTracker.UI/wwwroot/js/room.js'] }) // path to your entry file here
        .transform(vueify)
        //.plugin('vueify/plugins/extract-css', { out: './tmp/css/bundle.css' }) // path to where you want your css
        .transform(babelify, { "presets": ["@babel/preset-env"] })
        .external('vue') // remove vue from the bundle, if you omit this line whole vue will be bundled with your code
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(dest(distDir));

const build = done => parallel(bundle, copy)(done)

const spy = () => {
    watch(['./LinkedTracker.UI/wwwroot/js/**/*.js',
        './LinkedTracker.UI/Components/**/*.vue'],
        { ignoreInitial: false },
        build)
}

exports.watch = spy
exports.copy = copy
exports.bundle = bundle
exports.build = build
exports.default = build