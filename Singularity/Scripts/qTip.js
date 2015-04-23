
// qTip - CSS Tool Tips - by Craig Erskine
// http://qrayg.com
//
// Multi-tag support by James Crooke
// http://www.cj-design.com
//
// Inspired by code from Travis Beckham
// http://www.squidfingers.com | http://www.podlob.com
//
// Copyright (c) 2006 Craig Erskine
// Permission is granted to copy, distribute and/or modify this document
// under the terms of the GNU Free Documentation License, Version 1.3
// or any later version published by the Free Software Foundation;
// with no Invariant Sections, no Front-Cover Texts, and no Back-Cover Texts.
// A copy of the license is included in the section entitled "GNU
// Free Documentation License".

var qTipTag = "span,a,img,label,input,td,select"; //Which tag do you want to qTip-ize? Keep it lowercase!//
var TibAttribute = 'tiptitle';
var qTipX = 0; //This is qTip's X offset//
var qTipY = 15; //This is qTip's Y offset//
var optionIsSelected = false;
//There's No need to edit anything below this line//
tooltip = {
    name: "qTip",
    offsetX: qTipX,
    offsetY: qTipY,
    tip: null
}

tooltip.hide = function () {
    if (!this.tip) return;
    this.tip.innerHTML = "";
    this.tip.style.display = "none";
    this.tip.style.top = "0px";
    this.tip.style.left = "0px";
}

tooltip.init = function () {
    try {

        var tipNameSpaceURI = "http://www.w3.org/1999/xhtml";
        if (!tipContainerID) { var tipContainerID = "qTip"; }
        var tipContainer = document.getElementById(tipContainerID);

        if (!tipContainer) {
            tipContainer = document.createElementNS ? document.createElementNS(tipNameSpaceURI, "div") : document.createElement("div");
            tipContainer.setAttribute("id", tipContainerID);
            document.getElementsByTagName("body").item(0).appendChild(tipContainer);
        }

        if (!document.getElementById) return;
        this.tip = document.getElementById(this.name);
        if (this.tip) document.onmousemove = function (evt) { tooltip.move(evt) };

        var a, sTitle, elements;

        var elementList = qTipTag.split(",");
        for (var j = 0; j < elementList.length; j++) {
            elements = document.getElementsByTagName(elementList[j]);
            if (elements) {
                for (var i = 0; i < elements.length; i++) {
                    a = elements[i];

                    if (a && elementList[j] == 'select') {
                        try {
                            var selectedTitle = a.options[a.selectedIndex].getAttribute("title");
                            var selectedTitle2 = a.options[a.selectedIndex].getAttribute("tiptitle");

                            if (selectedTitle) {
                                a.setAttribute("title", selectedTitle);
                            }
                            else if (selectedTitle2) {
                                a.setAttribute("title", selectedTitle2);
                            }

                            if (a.getAttribute("onchange") == '' || a.getAttribute("onchange") == undefined) {
                                a.setAttribute("onchange",
                                a.getAttribute("onchange") + ";" +
                                "if (this.options[this.selectedIndex].getAttribute('" + TibAttribute + "') != undefined " +
                                " && this.options[this.selectedIndex].getAttribute('" + TibAttribute + "') != '') " +
                                "this.setAttribute('" + TibAttribute + "', this.options[this.selectedIndex].getAttribute('" + TibAttribute + "'));");
                            }
                        }
                        catch (ex) {
                        }
                    }
                    sTitle = a.getAttribute("title");

                    if (sTitle) {
                        a.setAttribute(TibAttribute, sTitle);
                        a.removeAttribute("title");
                        a.removeAttribute("alt");
                        if (elementList[j] == "option") {
                            a.onmouseover = function () {
                                optionIsSelected = true;
                                tooltip.show(this.getAttribute(TibAttribute))
                            };
                        }
                        else if (elementList[j] == "select") {
                            a.onmouseover = function () {
                                if (!optionIsSelected) {
                                    tooltip.show(this.getAttribute(TibAttribute));
                                }
                            };
                        }
                        else {
                            a.onmouseover = function () {
                                tooltip.show(this.getAttribute(TibAttribute))
                            };
                        }

                        if (elementList[j] == "option") {
                            a.onmouseout = function () {
                                optionIsSelected = false;
                                tooltip.hide();
                            };
                        }
                        else {
                            a.onmouseout = function () {
                                tooltip.hide();
                            };
                        }

                    }
                }
            }
        }
        tooltip.hide();

    } catch (ex) { alert(ex); }
}

tooltip.move = function (evt) {
    var x = 0, y = 0;
    if (document.all) {//IE
        x = (document.documentElement && document.documentElement.scrollLeft) ? document.documentElement.scrollLeft : document.body.scrollLeft;
        y = (document.documentElement && document.documentElement.scrollTop) ? document.documentElement.scrollTop : document.body.scrollTop;
        x += window.event.clientX;
        y += window.event.clientY;

    } else {//Good Browsers
        x = evt.pageX;
        y = evt.pageY;
    }
    this.tip.style.left = (x + this.offsetX) + "px";
    this.tip.style.top = (y + this.offsetY) + "px";
}

tooltip.show = function (text) {
    if (!this.tip) return;
    if (text != '') {

        while (text && text.indexOf('\n') > 0)
            text = text.replace('\n', '<br>');

        this.tip.innerHTML = text;
        this.tip.style.display = "block";
    }
}


window.onload = function () {
    tooltip.init();
}

/* Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(tooltip.init); */