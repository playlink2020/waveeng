﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSwinger : MonoBehaviour {

	#region Public variables
		[HeaderAttribute("Speed settings")]
		[Tooltip("How fast do the trees swing in the X axis")]
		[Range(0.001f,3f)]
		public float swingSpeedX;
		[Tooltip("The difference in swing speed of each tree in the X axis")]
		[Range(0,1f)]
		public float swingSpeedRandomnessX;
		
		[Tooltip("How fast do the trees swing in the Y axis")]
		[Range(0.001f,3f)]
		public float swingSpeedY;
		
		[Tooltip("The difference in swing speed of each tree in the Y axis")]
		[Range(0,1f)]
		public float swingSpeedRandomnessY;

	//Added Z
	[Tooltip("How fast do the trees swing in the Z axis")]
	[Range(0.001f, 3f)]
	public float swingSpeedZ;

	[Tooltip("The difference in swing speed of each tree in the Z axis")]
	[Range(0, 1f)]
	public float swingSpeedRandomnessZ;
	//

	[HeaderAttribute("Angle settings")]
		[Tooltip("How far do the trees swing in the X axis")]
		[Range(0.001f,20f)]
		public float swingMaxAngleX;
		[Tooltip("The difference in how far does each trees swing in the X axis")]
		[Range(0.001f,5f)]
		public float swingMaxAngleRandomnessX;
		
		[Tooltip("How far do the trees swing in the Y axis")]
		[Range(0.001f,180f)]
		public float swingMaxAngleY;
		[Tooltip("The difference in how far does each trees swing in the Y axis")]
		[Range(0.001f,15f)]
		public float swingMaxAngleRandomnessY;

	//Added Z
	[Tooltip("How far do the trees swing in the Z axis")]
	[Range(0.001f, 180f)]
	public float swingMaxAngleZ;
	[Tooltip("The difference in how far does each trees swing in the Z axis")]
	[Range(0.001f, 15f)]
	public float swingMaxAngleRandomnessZ;
	//	

		[HeaderAttribute("Direction settings")]
		[Tooltip("The \"wind\" direction in angles from standard X axis")]
		[Range(0f,180f)]
		public float direction;
		[Tooltip("The \"wind\" direction randomness")]
		[Range(0f,180f)]
		public float directionRandomness;
		public bool enableYAxisSwinging;
	
	#endregion

	#region Private variables
		List<SwingingTree> trees = new List<SwingingTree>();
		Vector3 swingDirection;
	#endregion

	void OnValidate() {
		for(int i = 0; i < trees.Count; i++){
			trees[i].tree.rotation = Quaternion.identity;
			trees[i].speedX = swingSpeedX+Random.Range(-swingSpeedRandomnessX,swingSpeedRandomnessX);
			trees[i].speedY = swingSpeedY + Random.Range(-swingSpeedRandomnessY,swingMaxAngleRandomnessY);
			trees[i].speedZ = swingSpeedZ + Random.Range(-swingSpeedRandomnessZ,swingMaxAngleRandomnessZ);
			trees[i].maxAngleX = swingMaxAngleX + Random.Range(-swingMaxAngleRandomnessX,swingMaxAngleRandomnessX);
			trees[i].maxAngleY = swingMaxAngleY + Random.Range(-swingMaxAngleRandomnessY,swingMaxAngleRandomnessY);
			trees[i].maxAngleZ = swingMaxAngleZ + Random.Range(-swingMaxAngleRandomnessZ,swingMaxAngleRandomnessZ);
			trees[i].direction = direction+Random.Range(-directionRandomness,directionRandomness);
		}
	}
	
	void Start(){
		foreach(Transform tree in transform){
			trees.Add(new SwingingTree(tree, swingSpeedX+Random.Range(-swingSpeedRandomnessX,swingSpeedRandomnessX), swingSpeedY+Random.Range(-swingSpeedRandomnessY,swingSpeedRandomnessY), swingSpeedZ+Random.Range(-swingSpeedRandomnessZ, swingSpeedRandomnessZ),
				swingMaxAngleX + Random.Range(-swingMaxAngleRandomnessX,swingMaxAngleRandomnessX),swingMaxAngleY+Random.Range(-swingMaxAngleRandomnessY,swingMaxAngleRandomnessY),
					swingMaxAngleZ + Random.Range(-swingMaxAngleRandomnessZ, swingMaxAngleRandomnessZ),direction +Random.Range(-directionRandomness,directionRandomness)));
		}
	}

	void Update () {
		for(int i = 0; i < trees.Count; i++){
			 trees[i].tree.rotation = Quaternion.Euler(trees[i].maxAngleX * Mathf.Sin(Time.time * trees[i].speedX), 
			 	(enableYAxisSwinging) ? trees[i].maxAngleY * Mathf.Sin(Time.time * trees[i].speedY) : trees[i].direction, trees[i].maxAngleZ * Mathf.Sin(Time.time * trees[i].speedZ));
		}
	}

}

public class SwingingTree{
	public Transform tree;
	public float speedX;
	public float speedY;
	public float speedZ;
	public float maxAngleX;
	public float maxAngleY;
	public float maxAngleZ;
	public float direction;

	public SwingingTree(Transform tree, float speedX,float speedY, float speedZ, float maxAngleX, float maxAngleY, float maxAngleZ, float direction){
		this.tree=tree;
		this.speedX=speedX;
		this.speedY=speedY;
		this.speedZ=speedZ;
		this.maxAngleX=maxAngleX;
		this.maxAngleY=maxAngleY;
		this.maxAngleZ=maxAngleZ;
		this.direction=direction;
	}
}
