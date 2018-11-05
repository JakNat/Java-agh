package pl.edu.agh.kis.java2015.domain;

import static org.junit.Assert.*;

import org.junit.Test;

import java.util.ArrayList;

public class HeapTest {
	
	@Test
	public void insert0intoNewHeap_topIs0() {
		
		Heap<Double> heap = new Heap<>();

		heap.insert(0.);
		
		assertEquals("size should be 1",1,heap.size());
		assertEquals(0,heap.top(),0.001);
		assertEquals(1,heap.size());

		assertTrue(heap.isHeap());
	}
	
	@Test
	public void insert0AndThen2intoNewHeap_topIs2() {
		
		Heap<Double> heap = new Heap<>();
		heap.insert(0.);
		heap.insert(2.);
		
		assertEquals("size should be 2",2,heap.size());
		assertEquals(2.,heap.top(),0.001);
		assertTrue(heap.isHeap());

	}
	
	@Test
	public void insert0And2And3And5And6intoNewHeap_topIs6() {
		
		Heap<Double> heap = new Heap<>();
		heap.insert(0.);
		heap.insert(2.);
		heap.insert(3.);
		heap.insert(5.);
		heap.insert(8.);
		heap.insert(2.4);
		heap.insert(4.5);
		heap.insert(7.);
		heap.insert(7.);
		heap.insert(14.);
		heap.insert(54.);
		heap.insert(24.);
		heap.insert(7.);

		assertEquals(54,heap.top(),0.001);

		heap.extract_max();

		assertEquals(24,heap.top(),0.001);
		assertTrue(heap.isHeap());
	}

	@Test
	public void extractMaxValue54_changeFor_24() {

		Heap<Double> heap = new Heap<>();
		heap.insert(0.);
		heap.insert(2.);
		heap.insert(3.);
		heap.insert(5.);
		heap.insert(8.);
		heap.insert(2.4);
		heap.insert(4.5);
		heap.insert(7.);
		heap.insert(7.);
		heap.insert(14.);
		heap.insert(54.);
		heap.insert(24.);
		heap.insert(7.);

		assertEquals(54,heap.top(),0.001);

		heap.extract_max();

		assertEquals(24,heap.top(),0.001);
		assertTrue(heap.isHeap());
	}

	@Test
	public void replaceextractMaxValue54_changeFor_24() {

		Heap<Double> heap = new Heap();
		heap.insert(0.);
		heap.insert(2.);
		heap.insert(3.);
		heap.insert(11.);
		heap.insert(12.);
		heap.insert(9.);
		heap.insert(10.);



		heap.replace_max(6.);

		assertEquals(11,heap.top(),0.001);
		assertTrue(heap.isHeap());
	}
	@Test
	public void heapifiNewHeapFromListCheckIfIsHeapTrue() {
		ArrayList<Double> array = new ArrayList<>();
		array.add(2.);
		array.add(3.);
		array.add(4.);
		array.add(8.);
		array.add(5.);
		array.add(6.);



		Heap<Double> heap = new Heap<>();
		heap.heapify(array);

		assertTrue(heap.isHeap());
		assertEquals(6,heap.size());
	}
	@Test
	public void mergeHeapCheckIfIsHeapTrue() {

		Heap<Double> heap = new Heap<>();
		heap.insert(0.);
		heap.insert(2.);
		heap.insert(3.);
		heap.insert(11.);
		heap.insert(12.);
		heap.insert(9.);
		heap.insert(10.);


		Heap<Double> heap2 = new Heap<>();
		heap2.insert(3.);
		heap2.insert(33.);
		heap2.insert(22.);
		heap2.insert(11.);

		Heap heap3 = heap.Merge(heap2);

		assertTrue(heap3.isHeap());
	}

	//Class for testing purpose
	class TestClass implements Comparable<TestClass>{

		private int value;

		TestClass(int value) {
			this.value = value;
		}

		@Override
		public int compareTo(TestClass testClass) {
			if(value > testClass.value){
				return 1;
			}else if(value < testClass.value){
				return -1;
			}
			return 0;
		}
	}
	@Test
	public void CheckIfHeapClassIsForInteger() {

		Heap<Integer> heap = new Heap<>();
		heap.insert(0);
		heap.insert(2);
		heap.insert(3);
		heap.insert(9);
		heap.insert(10);

		assertTrue(heap.isHeap());

	}

	@Test
	public void CheckIfHeapClassIsGenericForTestClassWhichImplementsComparator() {
		Heap<TestClass> heap = new Heap<>();
		heap.insert(new TestClass(3));
		heap.insert(new TestClass(11));
		heap.insert(new TestClass(6));
		heap.insert(new TestClass(8));
		heap.insert(new TestClass(1));

		assertTrue(heap.isHeap());
		assertEquals(11,heap.top().value);

	}



}
