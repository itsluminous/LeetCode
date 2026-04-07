class Robot {
    boolean moved = false;
    int idx = 0;
    List<int[]> pos = new ArrayList<>();
    List<Integer> dir = new ArrayList<>();
    Map<Integer, String> toDir = Map.of( 0, "East", 1, "North", 2, "West", 3, "South");

    public Robot(int width, int height) {
        for (int i = 0; i < width; ++i) {
            pos.add(new int[]{i, 0});
            dir.add(0);
        }
        for (int i = 1; i < height; ++i) {
            pos.add(new int[]{width - 1, i});
            dir.add(1);
        }
        for (int i = width - 2; i >= 0; --i) {
            pos.add(new int[]{i, height - 1});
            dir.add(2);
        }
        for (int i = height - 2; i > 0; --i) {
            pos.add(new int[]{0, i});
            dir.add(3);
        }
        dir.set(0, 3);
    }

    public void step(int num) {
        moved = true;
        idx = (idx + num) % pos.size();
    }

    public int[] getPos() {
        return pos.get(idx);
    }

    public String getDir() {
        if (!moved) return toDir.get(0);
        return toDir.get(dir.get(idx));
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.step(num);
 * int[] param_2 = obj.getPos();
 * String param_3 = obj.getDir();
 */