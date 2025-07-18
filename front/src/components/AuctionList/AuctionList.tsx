import {useEffect,useState} from "react"

interface IAuction{
    id:number,
    name:string,
    auctionDate:string,
}

export const AuctionList =()=>{
    const [auctions, setAuctions] = useState<IAuction[]>([])
    const [loading, setLoading] = useState(true)
    const [error, setError] = useState("")

    useEffect(()=>{
        const fetchAuctions = async () => {
            try {
                console.log('import.meta.env.VUE_API_URL',import.meta.env.VITE_API_URL);
                console.log('import.meta.env.VITE_API_TOCKEN',import.meta.env.VITE_API_TOCKEN);
                const response = await fetch(`${import.meta.env.VITE_API_URL}/api/auctions`, {
                    headers: {
                        Authorization: `Bearer ${import.meta.env.VITE_API_TOCKEN}`,
                    },
                });
                const data:IAuction[] = await response.json();
                if (Array.isArray(data)) {
                    setAuctions(data);
                }
                else{
                    setError("Error fetching actions");
                }

            } catch (err) {
                console.error("Error fetching actions:",err)
                if (err instanceof Error) {
                    setError(err.message);
                } else {
                    setError(String(err));
                }
            }
            finally {
                setLoading(false)
            }
        }

        fetchAuctions()
    },[])

    if (loading) {return <div>Loading....</div>}
    if (error) {return <div>Error in loading: {error}</div>}

    return (
    <div>
        <h2>Auctions</h2>
        {auctions.map(auction=>{
            return(
                <div key={auction.id}> {auction.name} - {new Date(auction.auctionDate).toLocaleDateString()} </div>
            )
        })}
    </div>
    )
}
