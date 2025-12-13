class Solution {
    public List<String> validateCoupons(String[] code, String[] businessLine, boolean[] isActive) {
        Map<String, String> blPriority = Map.of(
            "electronics", "0",
            "grocery", "1",
            "pharmacy", "2",
            "restaurant", "3"
        );

        List<String[]> valid = new ArrayList<String[]>();
        for(var i=0; i<code.length; i++){
            if(!isActive[i]) continue;
            if(!blPriority.containsKey(businessLine[i])) continue;
            if(!isValidCode(code[i])) continue;
            valid.add(new String[]{blPriority.get(businessLine[i]), code[i]});
        }

        valid.sort(Comparator.comparing((String[] a) -> a[0]).thenComparing(a -> a[1]));
        List<String> ans = valid.stream()
                           .map(a -> a[1])
                           .collect(Collectors.toCollection(ArrayList::new));
        
        return ans;
    }

    private boolean isValidCode(String code){
        if(code.length() == 0) return false;
        for(var ch : code.toCharArray()) {
            if(!Character.isLetterOrDigit(ch) && ch != '_')
                return false;
        }
        return true;
    }
}