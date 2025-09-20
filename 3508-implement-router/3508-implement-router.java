class Router {
    int memory;
    Set<String> packets;    // to track duplicates
    Queue<int[]> queue;     // FIFO tracking of queues
    Map<Integer, List<Integer>> destTimeStampMap;   // list of timestamp of packets for each destination


    public Router(int memoryLimit) {
        memory = memoryLimit;
        packets = new HashSet<>();
        queue = new LinkedList<>();
        destTimeStampMap = new HashMap<>();
    }
    
    public boolean addPacket(int source, int destination, int timestamp) {
        // check duplicate
        var identifier = getIdentifier(source, destination, timestamp);
        if(packets.contains(identifier)) return false;
        packets.add(identifier);
        
        // remove oldest packet if memory is full
        if(queue.size() == memory) forwardPacket();

        // add packet to queue
        queue.offer(new int[]{source, destination, timestamp});

        // track timestamp of packets    for each destination
        destTimeStampMap.putIfAbsent(destination, new ArrayList<>());
        destTimeStampMap.get(destination).add(timestamp);

        return true;
    }
    
    public int[] forwardPacket() {
        if(queue.isEmpty()) return new int[]{};
        
        var packet = queue.poll();
        int source = packet[0], destination = packet[1], timestamp = packet[2];

        var identifier = getIdentifier(source, destination, timestamp);
        packets.remove(identifier);

        // remove this packet from destination map
        destTimeStampMap.get(destination).remove(0);

        return packet;
    }
    
    public int getCount(int destination, int startTime, int endTime) {
        // check if there is any packet for destination
        var list = destTimeStampMap.get(destination);
        if (list == null || list.isEmpty()) return 0;

        // Perform binary search to count timestamps in [startTime, endTime]
        int left = lowerBound(list, startTime);
        int right = upperBound(list, endTime);

        return right - left;
    }

    private String getIdentifier(int source, int destination, int timestamp){
        return source + ":" + destination + ":" + timestamp;
    }

    private int lowerBound(List<Integer> list, int target) {
        int low = 0, high = list.size();
        while(low < high) {
            int mid = (low + high) >>> 1;
            if (list.get(mid) < target) low = mid + 1;
            else high = mid;
        }
        return low;
    }

    private int upperBound(List<Integer> list, int target) {
        int low = 0, high = list.size();
        while(low < high) {
            int mid = (low + high) >>> 1;
            if (list.get(mid) <= target) low = mid + 1;
            else high = mid;
        }
        return low;
    }
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * boolean param_1 = obj.addPacket(source,destination,timestamp);
 * int[] param_2 = obj.forwardPacket();
 * int param_3 = obj.getCount(destination,startTime,endTime);
 */