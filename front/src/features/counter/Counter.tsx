// src/features/counter/Counter.tsx
import { useAppDispatch, useAppSelector } from '../../hooks'
import { increment, decrement, reset } from './counterSlice'

export const Counter = () => {
    const count = useAppSelector(state => state.counter.value)
    const dispatch = useAppDispatch()

    return (
        <div>
            <h2>Count: {count}</h2>
            <button onClick={() => dispatch(increment())}>+1</button>
            <button onClick={() => dispatch(decrement())}>-1</button>
            <button onClick={() => dispatch(reset())}>Reset</button>
        </div>
    )
}
