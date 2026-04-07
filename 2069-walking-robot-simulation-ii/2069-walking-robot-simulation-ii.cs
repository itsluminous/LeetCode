public class Robot {
    bool moved = false;
    int idx = 0;
    List<int[]> pos = new List<int[]>();
    List<int> dir = new List<int>();
    Dictionary<int, string> toDir = new Dictionary<int, string>
    {{ 0, "East" }, { 1, "North" }, { 2, "West" }, { 3, "South" }};

    public Robot(int width, int height) {
        for(var i = 0; i < width; ++i) {
            pos.Add([i, 0]);
            dir.Add(0);
        }
        for(var i = 1; i < height; ++i) {
            pos.Add([width - 1, i]);
            dir.Add(1);
        }
        for(var i = width - 2; i >= 0; --i) {
            pos.Add([i, height - 1]);
            dir.Add(2);
        }
        for(var i = height - 2; i > 0; --i) {
            pos.Add([0, i]);
            dir.Add(3);
        }
        dir[0] = 3;
    }

    public void Step(int num) {
        moved = true;
        idx = (idx + num) % pos.Count;
    }

    public int[] GetPos() {
        return pos[idx];
    }

    public string GetDir() {
        if (!moved) return toDir[0];    // East
        return toDir[dir[idx]];
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.Step(num);
 * int[] param_2 = obj.GetPos();
 * string param_3 = obj.GetDir();
 */