import {useEffect,useState} from "react"

interface IAuction{
    id:number,
    name:string,
    auctionDate:string,
}
export const AuctionList =()=>{
    const [auctions, setAuctions] = useState<IAuction[]>([])
    const [loading, setLoading] = useState(true)

    useEffect(()=>{
        const fetchAuctions = async () => {
            try {
                console.log('import.meta.env.VUE_API_URL',import.meta.env.VITE_API_URL);
                const response = await fetch(`${import.meta.env.VITE_API_URL}/api/auctions`);
                const data:IAuction[] = await response.json();
                setAuctions(data);

            } catch (error) {
                console.error("Error fetching actions:",error)
            }
            finally {
                setLoading(false)
            }
        }

        fetchAuctions()
    },[])

    if (loading) {return <div>Loading....</div>}

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
