import { useEffect, useState } from "react";

export default function useFetch(url) {
  const [data, setData] = useState(null);
  const [isPending, setIsPending] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const abortController = new AbortController();
    fetch(url, { signal: abortController.signal })
      .then((response) => {
        if (!response.ok) {
          throw Error("SOMETHING WENT WRONG");
        }
        return response.json();
      })
      .then((data) => {
        setData(data.result);
        setIsPending(false);
        setError(null);
      })
      .catch((error) => {
        if (error.name === "AbortError") {
          console.error("FETCH ABORTED");
        } else {
          setIsPending(false);
          setError(error.message);
        }
      });
    // CLEANUP
    return () => abortController.abort();
  }, [url]);

  return { data, isPending, error };
}
