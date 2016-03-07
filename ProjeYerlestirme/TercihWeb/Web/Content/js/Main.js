window.onload = DuyuruYukle;
function DuyuruYukle() {
    $.ajax({
        type: "POST",
        url: "Duyurular.aspx/DuyurulariGoruntule",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (content) {

            var page = document.getElementsByClassName("sidebar_box")[0];
            for (var i = 0; i < content.d.length; i++) {
                var div = document.createElement("div");
                div.className = "news_box";
                var h3 = document.createElement("h3");
                
                var a = document.createElement("a");
                a.href = "Duyurular.aspx";
                var p = document.createElement("p");
                p.className = "post_info";
                h3.appendChild(document.createTextNode(content.d[i].DuyuruBasligi));
                var DuyuruIcerigi = (content.d[i].DuyuruIcerigi.length > 30) ? content.d[i].DuyuruIcerigi.substring(0, 30) : content.d[i].DuyuruIcerigi;
                DuyuruIcerigi += " ... ";
                a.appendChild(document.createTextNode(DuyuruIcerigi));
                var a2 = document.createElement("a");
                a2.appendChild(document.createTextNode(content.d[i].YayinlayanYetkili));
                var span = document.createElement("span");
                span.appendChild(document.createTextNode(content.d[i].Tarih));
                p.appendChild(a2);
                p.appendChild(document.createTextNode(" tarafından, "));
                p.appendChild(span);
                p.appendChild(document.createTextNode(" tarihinde yayınlanmıştır. "));

                div.appendChild(h3);
                div.appendChild(a);
                div.appendChild(p);
                page.appendChild(div);
            }


        }

    });


}
function Yonlendirme() {
    window.location = "Duyurular.aspx";
}