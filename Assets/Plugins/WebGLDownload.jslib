mergeInto(LibraryManager.library, {
  DownloadImageJS: function (str, fileName) {
    var base64 = Pointer_stringify(str);
    var link = document.createElement('a');
    link.download = Pointer_stringify(fileName);
    link.href = base64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  },
});