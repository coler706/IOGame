export class Cache {
    constructor() {
        this.bodies = {};
        this.groups = {};
        Cache.count = 0;
    }

    update(updates, deletes, groups, groupDeletes, time) {
        var i = 0;

        // delete objects that should no longer exist
        for (i = 0; i < deletes.length; i++) {
            var deleteKey = deletes[i];
            var key = "b-" + deleteKey;
            if (key in this.bodies) Cache.count--;
            delete this.bodies[key];
        }

        // delete groups that should no longer exist
        for (i = 0; i < groupDeletes.length; i++) {
            var deleteKey = groupDeletes[i];
            var key = "g-" + deleteKey;
            delete this.groups[key];
        }

        // update objects that should be here
        for (i = 0; i < updates.length; i++) {
            var update = updates[i];
            var existing = this.bodies["b-" + update.ID];

            this.bodies["b-" + update.ID] = update;
            if (existing) {
                existing.previous = false;
                existing.obsolete = time;
                update.previous = existing;

                if (update.Size === -1) update.Size = existing.Size;

                if (update.Sprite === null) update.Sprite = existing.Sprite;
                if (update.Caption === null) update.Caption = existing.Caption;
                if (update.Color === null) update.Color = existing.Color;

                if (update.OriginalAngle === -999) update.OriginalAngle = existing.OriginalAngle;
                if (update.AngularVelocity === -999) update.AngularVelocity = existing.AngularVelocity;
            }

            if (!existing) Cache.count++;
        }

        // update groups that should be here
        for (i = 0; i < groups.length; i++) {
            var group = groups[i];
            var existing = this.groups["g-" + group.ID];

            this.groups["g-" + group.ID] = group;
        }
    }

    foreach(action, thisObj) {
        var sortedGroups = [];

        for (var key in this.groups) {
            var group = this.groups[key];
            sortedGroups.push(group);
        }

        sortedGroups.sort(function(a, b) {
            return a.ZIndex - b.ZIndex;
        });
        sortedGroups.unshift({ ID: 0 });

        for (var g = 0; g < sortedGroups.length; g++) {
            var group = sortedGroups[g];

            for (var key in this.bodies) {
                if (key.indexOf("b-") === 0) {
                    var body = this.bodies[key];
                    if (body.Group == group.ID) {
                        action.apply(thisObj, [body]);
                    }
                }
            }
        }
    }

    getGroup(groupID) {
        return this.groups["g-" + groupID];
    }
}
