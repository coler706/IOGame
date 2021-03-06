﻿export class Log {
    constructor(canvas, context, settings) {
        settings = settings || {};
        this.context = context;
        this.canvas = canvas;
        this.data = [];
        this.lastDisplay = false;
    }

    addEntry(entry) {
        this.data.push(entry);
        this.data = this.data.slice(this.data.length - 4);
        this.lastDisplay = performance.now();
    }

    draw() {
        var ctx = this.context;
        ctx.save();
        if (this.data && this.lastDisplay) {
            var time = performance.now() - this.lastDisplay;

            var alpha = 1.0;
            if (time > 2000) alpha = 1.0 - Math.max(time - 2000, 1000) / 1000.0;
            if (time > 3000) alpha = 0;

            ctx.globalAlpha = alpha;

            ctx.font = "12pt sans-serif";
            ctx.fillStyle = "white";
            ctx.textAlign = "left";

            var rowHeight = 28;
            var margin = 20;

            for (var i = 0; i < this.data.length; i++) {
                var entry = this.data[i];

                ctx.fillStyle = "white";

                ctx.fillText(entry, margin, rowHeight + i * rowHeight);
            }
        }

        ctx.restore();
    }
}
