package pl.edu.agh.kis.java2015.domain;

import java.util.ArrayList;

public class Heap<T extends Comparable<T>> {

	private int heapSize = 0;
	private ArrayList<T> tab = new ArrayList<>();

	public void insert(T value) {
		int currentIndex = heapSize;
		int parentIndex = parentIndex(currentIndex);
		tab.add(value);
		while( isChildGreaterThanParent(currentIndex, parentIndex) ) {
			swapElements(currentIndex, parentIndex);
			currentIndex = parentIndex;
			parentIndex = parentIndex(currentIndex);
		}
		heapSize++;
	}

	public T extract_max() {
		int currentIndex = 0;

		//Geting value of the last leave
		T lastLeave = tab.get(heapSize - 1);
		//Geting value of the first leave
		T firstLeave = tab.get(0);

		//removing last Leave
		tab.remove(heapSize - 1);
		//change last leave for the first leave
		tab.set(0,lastLeave);
		while (isParentSmallerThanChild(currentIndex)){
		if(isFirstChildGreaterThanSecondChild(currentIndex)){
			swapElements(2 * currentIndex + 1, currentIndex);
			currentIndex = 2 * currentIndex + 1;
		}else {
			swapElements(2 * currentIndex + 2, currentIndex );
			currentIndex = 2 *  currentIndex + 2;
		}
		}
		heapSize--;
		return firstLeave;
	}
	public T replace_max(T value) {
		int currentIndex = 0;

		//Geting value of the last leave
		T lastLeave = tab.get(heapSize - 1);
		//Geting value of the first leave
		T firstLeave = tab.get(0);
		//change firt leave for the first leave
		tab.set(0,value);
		while (isParentSmallerThanChild(currentIndex)){
			if(isFirstChildGreaterThanSecondChild(currentIndex)){
				swapElements(2 * currentIndex + 1, currentIndex);
				currentIndex = 2 * currentIndex + 1;
			}else {
				swapElements(2 * currentIndex + 2, currentIndex );
				currentIndex = 2 *  currentIndex + 2;
			}
		}
		return firstLeave;
	}
	public Heap Merge(Heap<T> heap2){
		Heap mergedHeap = new Heap();
		for (T d: tab) {
			mergedHeap.insert(d);
		}
		for (T d: heap2.tab) {
			mergedHeap.insert(d);
		}
		return mergedHeap;
	}

	public boolean isChildGreaterThanParent(int currentIndex, int parentIndex) {
		if( tab.get(currentIndex).compareTo(tab.get(parentIndex)) == 1){
			return true;
		}
		return false;

	}

	public boolean isParentSmallerThanChild(int parentIndex) {
		int firstChildIndex = parentIndex * 2 + 1;
		int secondChildIndex = parentIndex * 2 + 2;
		T parentValue = tab.get(parentIndex);
		//geting children value
		//catch error if they don t exist
		T firstChildValue;
		try {
			firstChildValue = tab.get(firstChildIndex);
		}catch (Exception e){
			return false;
		}
		T secondChildValue;
		try {
			secondChildValue = tab.get(secondChildIndex);
		}catch (Exception e){

			if(firstChildValue.compareTo(parentValue) == 1){
				return true;
			}
			return false;

		/*	if(firstChildValue > parentValue){
				return true;
			}else{
				return false;
			}
*/		}
		if(firstChildValue.compareTo(parentValue) == 1|| secondChildValue.compareTo(parentValue) == 1){
			return true;
		}else {
			return false;
		}
	}
	public boolean isFirstChildGreaterThanSecondChild(int parentIndex){
		int firstChildIndex = parentIndex * 2 + 1;
		int secondChildIndex = parentIndex * 2 + 2;
		//geting children value
		//catch error if they don t exist
		T firstChildValue;
		firstChildValue = tab.get(firstChildIndex);

		T secondChildValue;
		try {
			secondChildValue = tab.get(secondChildIndex);
		}catch (Exception e){
			return true;
		}
		if(firstChildValue.compareTo(secondChildValue) == 1){
			return true;
		}else {
			return false;
		}
	}
	public  boolean isHeap() {

		int N = tab.size();
		if (N <= 1){
			return true;
		}
		for (int i = (N - 2) / 2; i > -1; --i) { // start from the first internal node who has children;
			int j = 2 * i + 1; // the left child;
			if (j < N - 1 && tab.get(i).compareTo(tab.get(j+1)) == 1 ) j++; // select the bigger child;
			T xx = tab.get(i);
			T x2 = tab.get(j);
			if (tab.get(i).compareTo(tab.get(j)) == 0) return false; // if parent is smaller than the child;
		}
		return true;
	}

	public void swapElements(int currentIndex, int parentIndex) {
		T parentValue = parentValue(currentIndex);
		T currentValue = tab.get(currentIndex);
		tab.set(parentIndex, currentValue);
		tab.set(currentIndex, parentValue);
	}

	public T parentValue(int currentIndex) {
		T parentValue = tab.get(parentIndex(currentIndex));
		return parentValue;
	}

	public int parentIndex(int currentIndex) {
		return (currentIndex - 1)/2;
	}

	public int size() {
		return heapSize ;
	}

	public T top() {
		return tab.get(0);
	}

	public void heapify(ArrayList<T> array) {
		for (T a: array) {
			this.insert(a);
		}
	}
}
