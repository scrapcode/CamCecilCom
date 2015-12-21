
var gulp = require('gulp');
var less = require('gulp-less');
var path = require('path');

var lessSrc = './Content/Styles/less/**/*.less';

gulp.task('build-less', function () {
    return gulp.src( lessSrc )
        .pipe(less({
            paths: [path.join(__dirname, 'less', 'includes')]
        }))
        .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('watch', function () {
    gulp.watch(lessSrc, ['build-less']);
});