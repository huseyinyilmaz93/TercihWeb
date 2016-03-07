window.onload = DuyuruYukle;
function DuyuruYukle() {
    $.ajax({
        type: "POST",
        url: "Duyurular.aspx/DuyurulariGoruntule",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (content) {
            document.getElementById("duyuru").innerHTML = ""; 
            for (var i = 0; i < content.d.length; i++) {
                var h3 = document.createElement("h3");
                h3.style.cursor = "pointer";
                h3.appendChild(document.createTextNode(content.d[i].DuyuruBasligi));
                document.getElementById("duyuru").appendChild(h3);

                var p = document.createElement("p");
                p.appendChild(document.createTextNode(content.d[i].DuyuruIcerigi));
                p.style.display = "none";
                document.getElementById("duyuru").appendChild(p);
                

                var span = document.createElement("p");
                span.style.fontSize = "11px";
                var spanYetkili = document.createElement("a");
                spanYetkili.className = "yetkili";
                spanYetkili.style.fontSize = "11px";
                spanYetkili.style.color = "#666666";
                spanYetkili.appendChild(document.createTextNode(content.d[i].YayinlayanYetkili));
                var spanTarih = document.createElement("span");
                spanTarih.className = "tarih";
                spanTarih.style.color = "#157ad2";
                spanTarih.style.fontWeight = "normal";
                spanTarih.appendChild(document.createTextNode(content.d[i].Tarih));
                span.style.display = 'none';

                span.appendChild(spanYetkili);
                span.appendChild(document.createTextNode(" tarafından, "))
                span.appendChild(spanTarih);
                span.appendChild(document.createTextNode(" tarihinde yayınlanmıştır. "));

                document.getElementById("duyuru").appendChild(document.createElement("br"));
                document.getElementById("duyuru").appendChild(document.createElement("br"));
                document.getElementById("duyuru").appendChild(span);

                h3.addEventListener("click", fx, true);
                h3.p = p;
                h3.span = span;
            }

        }

    });
}
function fx(params) {
    if (params.target.p.style.display == 'inline')
    {
        params.target.p.style.display = 'none'
        params.target.span.style.display = 'none'
    }  else if (params.target.p.style.display == 'none') {
        params.target.p.style.display = 'inline';
        params.target.span.style.display = 'inline';
    }
}