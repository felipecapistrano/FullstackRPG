import { useState, useEffect } from "react"
import api from "../../api"

const useDataFetch = (url) => {
    const [data, setData] = useState("");
   
    useEffect(() => {
      const fetchData = async () => {
        try {
          const result = await api.get(url);
   
          setData(result.data);
        } catch (error) {
          alert("deu ruim");
        }
      };
   
      fetchData();
    }, [url]);
   
    return data;
  }

  export default useDataFetch